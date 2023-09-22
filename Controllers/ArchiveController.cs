using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Controllers
{
	[Authorize]
	public class ArchiveController : Controller
	{
		private readonly IWebHostEnvironment Environment;
		private readonly IConfiguration Configuration;
		private readonly AppDBContext dbContext;
		private readonly UserManager<AppUser> userManager;

		public ArchiveController(IWebHostEnvironment _environment, IConfiguration configuration, AppDBContext db, UserManager<AppUser> userMngr)
		{
			Environment = _environment;
			Configuration = configuration;
			dbContext = db;
			userManager = userMngr;
		}

		public async Task<IActionResult> Index()
		{
			if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") != "true")
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				return View(await dbContext.tArchives.Where(a => a.IsDeleted == "0" && !a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ToListAsync());
			}
		}

		
		public IActionResult Download(string FileName)
		{
			string fileDir = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
			string filePath = Path.Combine(Environment.WebRootPath, fileDir, FileName);

			return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), FileName);
		}

		public IActionResult Delete(string FileName, string view)
		{
			string fileDir = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
			string filePath = Path.Combine(Environment.WebRootPath, fileDir, FileName);

			System.IO.File.Delete(filePath);
			dbContext.tArchives.Where(a => a.FileName == FileName).FirstOrDefault().IsDeleted = "1";
			dbContext.SaveChanges();

			ViewBag.Status = $"{FileName} was deleted successsfully.";

			if(view == "Index")
			{
				return View("Index", dbContext.tArchives.Where(a => a.IsDeleted == "0" && !a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ToList());
			}
			else
			{
				return View("PreviousRepository", dbContext.tArchives.Where(a => a.IsDeleted == "0" && a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ThenBy(a => a.FileName).ToList());
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
					ViewBag.UploadMsg = "Error/s encountered.";
					return View("Index", await dbContext.tArchives.Where(a => a.IsDeleted == "0" && !a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ToListAsync());
				}

				//List<string> activeFileNames = dbContext.tSpreadsheets.Select(a => a.FileName).ToList();
				List<string> archiveFileNames = new List<string>();
				archiveFileNames.Add("FASB_COD_Metadata_New");
				archiveFileNames.Add("FASB_COD_NAMING");
				archiveFileNames.Add("FASB DITA Codification Tracking");

				string[] allowedExtensions = { ".xls", ".xlsx" };
				//var activeFiles = dbContext.tSpreadsheets.ToList();

				List<string> errorList = new();
				DateTime fileDate = DateTime.Now;

				foreach (IFormFile postedFile in postedFiles)
				{
					string fileName = postedFile.FileName;
					if (postedFile.Length == 0)
					{
						errorList.Add($"{fileName} - File is empty.");
						continue;
					}

					string fileExtension = Path.GetExtension(fileName).ToLowerInvariant();

					if (!Array.Exists(allowedExtensions, ext => ext.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
					{
						errorList.Add($"{fileName} - File type should be 'xls, xlsx and html'");
						continue;
					}

					if (fileName.Length < 34)
					{
						errorList.Add($"{fileName} - File doesn't match required name length.");
						continue;
					}

					string fileNameTrimmed = "";

					if (fileExtension == ".xls")
					{
						fileNameTrimmed = fileName.Substring(0, fileName.Length - 19);
					}
					else
					{
						fileNameTrimmed = fileName.Substring(0, fileName.Length - 20);
					}



					//check for matching file name
					if (!archiveFileNames.Contains(fileNameTrimmed))
					{
						errorList.Add($"{fileName} - File doesn't match required file name.");
					}
					//check for extension
					else
					{
						bool isNumeric = (fileExtension == ".xls") ? long.TryParse(fileName.Substring(fileName.Length - 18, 14), out _) : long.TryParse(fileName.Substring(fileName.Length - 19, 14), out _);

						if (isNumeric)
						{
							var doesExist = dbContext.tArchives.Where(a => a.FileName == fileName && a.IsDeleted == "0").Select(a => a.FileName).FirstOrDefault();

							if (doesExist == null || doesExist == "")
							{
								string fileDateTrim = (fileExtension == ".xls") ? fileName.Substring(fileName.Length - 18, 14) : fileName.Substring(fileName.Length - 19, 14);
								int fileYear = Convert.ToInt32(fileDateTrim.Substring(0, 4));
								int fileMonth = Convert.ToInt32(fileDateTrim.Substring(4, 2));
								int fileDay = Convert.ToInt32(fileDateTrim.Substring(6, 2));
								int fileHour = Convert.ToInt32(fileDateTrim.Substring(8, 2));
								int fileMin = Convert.ToInt32(fileDateTrim.Substring(10, 2));
								int fileSec = Convert.ToInt32(fileDateTrim.Substring(12, 2));

								fileDate = new DateTime(fileYear, fileMonth, fileDay, fileHour, fileMin, fileSec);
							}
							else
							{
								errorList.Add($"{fileName} - File is already archived.");
								continue;
							}
						}

						else
						{
							errorList.Add($"{fileName} - File extension format should be '_YYYYMMDDHHmmss.xls'.");
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

					ViewBag.UploadMsg = "Error/s encountered.";
					return View("Index", await dbContext.tArchives.Where(a => a.IsDeleted == "0" && !a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ToListAsync());
				}

				List<string> lstUploadedFiles = new();

				foreach (var formFile in postedFiles)
				{
					string fileName = formFile.FileName;

					string dirArchive = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
					string filePathArchive = Path.Combine(Environment.WebRootPath, dirArchive);

					using (var stream = new FileStream(Path.Combine(filePathArchive, fileName), FileMode.Create))
					{
						//upload
						await formFile.CopyToAsync(stream);
						lstUploadedFiles.Add(fileName);

						//update database
						double size = (double)formFile.Length / 1000;
						var archiveModel = new ArchiveModel();
						archiveModel.FileName = fileName;
						archiveModel.Size = size.ToString();
						archiveModel.DateCreated = fileDate;
						archiveModel.CreatedBy = user;
						archiveModel.IsDeleted = "0";

						await dbContext.tArchives.AddAsync(archiveModel);
						await dbContext.SaveChangesAsync();
					}
				}

				ViewBag.UploadMsg += string.Format("File upload was <b>successful</b>.<br />");
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

			return View("Index", await dbContext.tArchives.Where(a => a.IsDeleted == "0" && !a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ToListAsync());
		}


		public async Task<IActionResult> PreviousRepository()
		{
			return View(await dbContext.tArchives.Where(a => a.IsDeleted == "0" && a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ThenBy(a => a.FileName).ToListAsync());
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
