using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWebHostEnvironment Environment;
		private readonly IConfiguration Configuration;
		private readonly UserManager<AppUser> userManager;
		private readonly AppDBContext dbContext;

		public HomeController(IWebHostEnvironment _environment, IConfiguration configuration, AppDBContext db
							, UserManager<AppUser> userManager)
		{
			Environment = _environment;
			Configuration = configuration;
			this.userManager = userManager;
			dbContext = db;
		}

		[Authorize]
		public async Task<IActionResult> Index()
		{
			if(HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") != "true")
			{
				return RedirectToAction("VerifyAuth", "Login");
			}
			else
			{
				return View(await dbContext.tSpreadsheets.Where(a => a.Active == true).OrderByDescending(a => a.FileName).ToListAsync());
			}
		}

		[Authorize]
		[DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
		ValueLengthLimit = int.MaxValue)]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> Upload(List<IFormFile> postedFiles)
		{
            try
            {
				string user = userManager.GetUserAsync(User).Result.FirstName + " " + userManager.GetUserAsync(User).Result.LastName;

				if (postedFiles.Count == 0)
				{
					ModelState.AddModelError(string.Empty, "No files selected.");

					return View("Index", await dbContext.tSpreadsheets.Where(a => a.Active == true).OrderByDescending(a => a.FileName).ToListAsync());
				}

				List<string> activeFileNames = dbContext.tSpreadsheets.Select(a => a.FileName).ToList();
				var activeFiles = dbContext.tSpreadsheets.ToList();

				activeFileNames = new List<string>();
				activeFileNames.Add("FASB_COD_Metadata_New");
				activeFileNames.Add("FASB_COD_NAMING");
				activeFileNames.Add("FASB DITA Codification Tracking");
				activeFileNames.Add("KPMG US Build Tracking");

				List<string> errorList = new();
				string[] allowedExtensions = { ".xls", ".xlsx" };

				foreach (IFormFile postedFile in postedFiles)
				{
					string fileName = postedFile.FileName;
					if (postedFile.Length == 0)
					{
						errorList.Add($"{fileName} - File is empty.");
					}

					string filenameWithoutExt = Path.GetFileNameWithoutExtension(postedFile.FileName);
					string fileExtension = Path.GetExtension(fileName).ToLowerInvariant();

					if (!Array.Exists(allowedExtensions, ext => ext.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
					{
						errorList.Add($"{fileName} - File type should be 'xls, xlsx and html'");
						continue;
					}

                    // UNCOMMENT IN LIVE
                    // check for matching file name
                    if (!activeFileNames.Contains(filenameWithoutExt))
                        {
                            errorList.Add($"{filenameWithoutExt} - File doesn't match any active file.");
                        }
                        //check for locking
                        else
                        {

                            if ((activeFiles.Where(a => a.FileName == fileName).Select(a => a.IsLocked)
                                .FirstOrDefault()) == "Y")
                            {
                                if (!((activeFiles.Where(a => a.FileName == fileName && a.Controller == user).Select(a => a.IsLocked)
                                .FirstOrDefault()) == "Y"))
                                {
                                    errorList.Add($"{fileName} - File is locked by another user.");
                                }
                            }

                            else
                            {
                                errorList.Add($"{fileName} - File should be locked for upload.");
                            }
                        }
                }

				if (errorList.Count != 0)
				{
					ModelState.AddModelError(string.Empty, "File upload was terminated. No files were uploaded.");
					foreach (string errorMsg in errorList)
					{
						ModelState.AddModelError(string.Empty, errorMsg);
					}

					return View("Index", await dbContext.tSpreadsheets.Where(a => a.Active == true).OrderByDescending(a => a.FileName).ToListAsync());
				}

				List<string> lstUploadedFiles = new();

				foreach (var formFile in postedFiles)
				{
					string fileName = formFile.FileName;

					string dir = Configuration.GetSection("DirectorySettings")["SpreadsheetsDirectory"];
					string filePath = Path.Combine(Environment.WebRootPath, dir);

					string dirArchive = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
					string filePathArchive = Path.Combine(Environment.WebRootPath, dirArchive);

					//move and rename file and update database
					FileInfo oldFile = new FileInfo(Path.Combine(filePath, fileName));
					double oldSize = (double)oldFile.Length / 1000;

					DateTime dateNow = DateTime.Now;
					var archiveModel = new ArchiveModel();
					archiveModel.FileName = fileName.Replace(".xls", "") + "_" + dateNow.ToString("yyyyMMddHHmmss") + ".xls";
					archiveModel.Size = oldSize.ToString();
					archiveModel.DateCreated = dateNow;
					archiveModel.CreatedBy = user;
					archiveModel.IsDeleted = "0";

					await dbContext.tArchives.AddAsync(archiveModel);

					System.IO.File.Move(Path.Combine(filePath, fileName), Path.Combine(filePathArchive, fileName.Replace(".xls", "") +
						"_" + dateNow.ToString("yyyyMMddHHmmss") + ".xls"));

					using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
					{
						//upload
						await formFile.CopyToAsync(stream);
						lstUploadedFiles.Add(fileName);

						//update database
						double size = (double)formFile.Length / 1000;
						dbContext.tSpreadsheets.Where(a => a.FileName == fileName).FirstOrDefault().Size = size.ToString();
						dbContext.tSpreadsheets.Where(a => a.FileName == fileName).FirstOrDefault().DateCreated = dateNow;
						dbContext.tSpreadsheets.Where(a => a.FileName == fileName).FirstOrDefault().CreatedBy = user;

						await dbContext.SaveChangesAsync();
					}

				}

				ViewBag.UploadMsg += string.Format("File upload was <b>successful<b>.<br />");
				foreach (string fileName in lstUploadedFiles)
				{
					ViewBag.UploadMsg += string.Format("<b>{0}</b> was uploaded.<br />", fileName);
				}
			}
            catch (Exception ex)
            {
				// Redirect to the error view with a user-friendly message
				return RedirectToAction("Error", "Home", new { message = ex.Message });
			}

			return View("Index", await dbContext.tSpreadsheets.Where(a => a.Active == true).OrderByDescending(a => a.FileName).ToListAsync());
		}

		[Authorize]
		public async Task<IActionResult> Download(string filename, string controllerName, string isLocked)
		{
			string hasAccess = HasAccess(controllerName, isLocked, "Download");

			if (hasAccess == "true")
			{
				string fileDir = Configuration.GetSection("DirectorySettings")["SpreadsheetsDirectory"];
				string filePath = Path.Combine(Environment.WebRootPath, fileDir, filename);

				return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), filename);
			}
			else
			{
				ViewBag.Status = "File should be locked by user.";
				return View("Index", await dbContext.tSpreadsheets.Where(a => a.Active == true).OrderByDescending(a => a.FileName).ToListAsync());
			}
			
		}

		[Authorize]
		public string HasAccess(string controllerName, string isLocked, string reason)
		{
			string user = userManager.GetUserAsync(User).Result.FirstName + " " + userManager.GetUserAsync(User).Result.LastName;
			string hasAccess;

			if (isLocked == "Y")
			{
				if(controllerName == user)
				{
					hasAccess = "true";
				}
				else
				{
					hasAccess = "false";
				}
			}
			else
			{
				if(reason == "Lock")
				{
					hasAccess = "true";
				}
				else
				{
					hasAccess = "false";
				}				
			}
			
			return hasAccess;
		}

		[Authorize]
		public async Task<IActionResult> Lock(string filename, string controllerName, string isLocked)
		{

			string hasAccess = HasAccess(controllerName, isLocked, "Lock");

			string status;
			if (hasAccess == "true")
			{
				if (isLocked == "N")
				{
					dbContext.tSpreadsheets.Where(a => a.FileName == filename).FirstOrDefault().IsLocked = "Y";
					dbContext.tSpreadsheets.Where(a => a.FileName == filename).FirstOrDefault().Controller = userManager.GetUserAsync(User).Result.FirstName + " " + userManager.GetUserAsync(User).Result.LastName;

					status = "File was locked successfully.";
				}

				else
				{
					dbContext.tSpreadsheets.Where(a => a.FileName == filename).FirstOrDefault().IsLocked = "N";
					dbContext.tSpreadsheets.Where(a => a.FileName == filename).FirstOrDefault().Controller = null;

					status = "File was unlocked successfully.";
				}
				dbContext.SaveChanges();
			}
			else
			{
				status = "File is locked by another user.";
			}

			ViewBag.Status = status;
			return View("Index", await dbContext.tSpreadsheets.Where(a => a.Active == true).OrderByDescending(a => a.FileName).ToListAsync());
		}

		[AllowAnonymous]
		public IActionResult Error(string message)
		{
			
			var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

			if (exceptionHandlerPathFeature == null)
			{
				if (string.IsNullOrEmpty(message))
				{
					ViewBag.ExceptionMessage = "No available exception message.";
				}
				else
				{
					ViewBag.ErrorMessage = message;
					ViewBag.InnerMessage = message;
				}
			}
			else
			{
				string errorMsg = exceptionHandlerPathFeature.Error.Message;

				if (errorMsg == "Object reference not set to an instance of an object.")
				{
					ViewBag.ExceptionMessage = "No available error message instance.";
					if (exceptionHandlerPathFeature.Error.InnerException != null)
					{
						ViewBag.InnerMessage = exceptionHandlerPathFeature.Error.InnerException.Message;
					}

				}
				else
				{
					ViewBag.ExceptionMessage = errorMsg;
					if (exceptionHandlerPathFeature.Error.InnerException != null)
					{
						ViewBag.InnerMessage = exceptionHandlerPathFeature.Error.InnerException.Message;
					}
				}

			}

			return View();
		}
	}
}
