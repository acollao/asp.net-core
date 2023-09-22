using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class FasbCompareController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        private readonly IConfiguration Configuration;
        private readonly AppDBContext dbContext;
        private readonly UserManager<AppUser> userManager;

        public FasbCompareController(IWebHostEnvironment environment, IConfiguration configuration, AppDBContext dbContext, UserManager<AppUser> userManager)
        {
            Environment = environment;
            Configuration = configuration;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "compare").OrderByDescending(a => a.DateCreated).ToListAsync());
            }
        }

        [Authorize]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
         ValueLengthLimit = int.MaxValue)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> postedFiles)
        {
            string user = userManager.GetUserAsync(User).Result.FirstName + " " + userManager.GetUserAsync(User).Result.LastName;

            if (postedFiles.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No files selected.");
                ViewBag.UploadMsg = "Error/s encountered.";
                return View("Index", await dbContext.tArchives.Where(a => a.IsDeleted == "0" && !a.FileName.Contains("_16")).OrderByDescending(a => a.DateCreated).ToListAsync());
            }

            List<string> errorList = new();
            DateTime fileDate = DateTime.Now;
            // Define an array of allowed file extensions
            string[] allowedExtensions = { ".xls", ".xlsx"};
            string[] category = { "compare", "complete" };

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

                if (fileName.Contains("FASB", StringComparison.OrdinalIgnoreCase) == false)
                {
                    errorList.Add($"{fileName} - File doesn't match required filenaming.");
                    continue;
                }

                //if (!category.All(word => fileName.Contains(word, StringComparison.OrdinalIgnoreCase)))
                //{
                //    errorList.Add($"{fileName} - File doesn't match required filenaming.");
                //    continue;
                //}

                Console.WriteLine(fileName);
                var doesExist = dbContext.tReports.Where(a => a.FileName == fileName && a.IsDeleted == false).Select(a => a.FileName).FirstOrDefault();
                if (doesExist != null)
                {
                    if (doesExist.Any())
                    {
                        errorList.Add($"{fileName} - File alread archived.");
                        continue;
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

                return View("Index", await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "compare").OrderByDescending(a => a.DateCreated).ToListAsync());
            }

            List<string> lstUploadedFiles = new();

            foreach (var formFile in postedFiles)
            {
                string fileName = formFile.FileName;

                string dirArchive = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
                string filePathArchive = Path.Combine(Environment.WebRootPath, dirArchive);
                string pubType = (fileName.Contains("FASB", StringComparison.OrdinalIgnoreCase)) ? "FASB" : "GASB";
                string _category = (fileName.Contains("compare", StringComparison.OrdinalIgnoreCase)) ? "compare" : "complete";

                using (var stream = new FileStream(Path.Combine(filePathArchive, fileName), FileMode.Create))
                {
                    //upload
                    await formFile.CopyToAsync(stream);
                    lstUploadedFiles.Add(fileName);

                    //update database
                    double size = (double)formFile.Length / 1000;
                    var archiveModel = new ReportModel();
                    archiveModel.FileName = fileName;
                    archiveModel.Size = size.ToString();
                    archiveModel.DateCreated = fileDate;
                    archiveModel.CreatedBy = user;
                    archiveModel.IsDeleted = false;
                    archiveModel.PubType = pubType;
                    archiveModel.Category = _category;

                    await dbContext.tReports.AddAsync(archiveModel);
                    await dbContext.SaveChangesAsync();
                }
            }

            ViewBag.UploadMsg += string.Format("File upload was <b>successful</b>.<br />");
            foreach (string fileName in lstUploadedFiles)
            {
                ViewBag.UploadMsg += string.Format("<b>{0}</b> was uploaded.<br />", fileName);
            }


            return View("Index", await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "compare").OrderByDescending(a => a.DateCreated).ToListAsync());
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
            dbContext.tReports.Where(a => a.FileName == FileName).FirstOrDefault().IsDeleted = false;
            dbContext.SaveChanges();

            ViewBag.Status = $"{FileName} was deleted successsfully.";

            return View("Index", dbContext.tReports.Where(a => a.IsDeleted == false).OrderByDescending(a => a.DateCreated).ToList());

        }
    }
}
