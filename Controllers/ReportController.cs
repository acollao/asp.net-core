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
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        private readonly IConfiguration Configuration;
        private readonly AppDBContext dbContext;
        private readonly UserManager<AppUser> userManager;

        public ReportController(IWebHostEnvironment environment, IConfiguration configuration, AppDBContext dbContext, UserManager<AppUser> userManager)
        {
            Environment = environment;
            Configuration = configuration;
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public async Task<IActionResult> FASBCompare()
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

        public async Task<IActionResult> FASBComplete()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "complete").OrderByDescending(a => a.DateCreated).ToListAsync());
            }
        }

        public async Task<IActionResult> GASBCompare()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "complete").OrderByDescending(a => a.DateCreated).ToListAsync());
            }
        }

        public async Task<IActionResult> GASBComplete()
        {
            if (HttpContext.Session.GetString("username") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") == null || HttpContext.Session.GetString("IsValidTwoFactorAuthentication") != "true")
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "complete").OrderByDescending(a => a.DateCreated).ToListAsync());
            }
        }

        [Authorize]
        [DisableRequestSizeLimit, RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
         ValueLengthLimit = int.MaxValue)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> postedFiles, string view)
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

            //var activeFiles = dbContext.tSpreadsheets.ToList();

            List<string> errorList = new();
            DateTime fileDate = DateTime.Now;
            // Define an array of allowed file extensions
            string[] allowedExtensions = { ".xls", ".xlsx", ".html" };
            string[] category = { "compare", "complete" };

            foreach (IFormFile postedFile in postedFiles)
            {
                string fileName = postedFile.FileName;

                string pubType = (fileName.Contains("FASB", StringComparison.OrdinalIgnoreCase)) ? "FASB" : "GASB";
                string _category = (fileName.Contains("compare", StringComparison.OrdinalIgnoreCase)) ? "compare" : "complete";

                // Define a dictionary to map pubType and _category values to view names
                var viewMappings = new Dictionary<(string PubType, string Category), string>
                {
                    { ("FASB", "compare"), "fasbcompare" },
                    { ("FASB", "complete"), "fasbcomplete" },
                    { ("GASB", "compare"), "gasbcompare" },
                    { ("GASB", "complete"), "gasbcomplete" }
                };

                // Look up the view name based on pubType and _category
                if (viewMappings.TryGetValue((pubType, _category), out var mappedView))
                {
                    view = mappedView;
                }
                else
                {
                    // Default view name if there's no mapping
                    view = "fasbcompare";
                }

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

                bool containsFASBGASB = fileName.Contains("FASB", StringComparison.OrdinalIgnoreCase) || fileName.Contains("GASB", StringComparison.OrdinalIgnoreCase);
                bool containsCompareOrComplete = fileName.Contains("COMPARE", StringComparison.OrdinalIgnoreCase) || fileName.Contains("COMPLETE", StringComparison.OrdinalIgnoreCase);

                if (!(containsFASBGASB && containsCompareOrComplete))
                {
                    errorList.Add($"{fileName} - File doesn't match required filenaming.");
                    continue;
                }

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

                string _actionName = "";
                var query = dbContext.tReports.Where(a => a.IsDeleted == false);

                switch (view)
                {
                    case "fasbcompare":
                        _actionName = "FASBCompare";
                        query = query.Where(a => a.PubType == "FASB" && a.Category == "compare");
                        break;
                    case "fasbcomplete":
                        _actionName = "FASBComplete";
                        query = query.Where(a => a.PubType == "FASB" && a.Category == "complete");
                        break;
                    case "gasbcompare":
                        _actionName = "GASBCompare";
                        query = query.Where(a => a.PubType == "GASB" && a.Category == "compare");
                        break;
                    default:
                        _actionName = "GASBComplete";
                        query = query.Where(a => a.PubType == "GASB" && a.Category == "complete");
                        break;
                }

                var result = await query.OrderByDescending(a => a.DateCreated).ToListAsync();
                return View(_actionName, result);

                //if (view == "fasbcompare")
                //{
                //    return View("FASBCompare", await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "compare").OrderByDescending(a => a.DateCreated).ToListAsync());
                //}
                //else if (view == "fasbcomplete")
                //{
                //    return View("FASBComplete", await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "FASB" && a.Category == "complete").OrderByDescending(a => a.DateCreated).ToListAsync());
                //}
                //else if (view == "gasbcompare")
                //{
                //    return View("GASBComplete", await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "GASB" && a.Category == "complete").OrderByDescending(a => a.DateCreated).ToListAsync());
                //}
                //else
                //{
                //    return View("GASBComplete", await dbContext.tReports.Where(a => a.IsDeleted == false && a.PubType == "GASB" && a.Category == "complete").OrderByDescending(a => a.DateCreated).ToListAsync());
                //}

            }

            List<string> lstUploadedFiles = new();

            foreach (var formFile in postedFiles)
            {
                string fileName = formFile.FileName;

                string dirArchive = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
                string filePathArchive = Path.Combine(Environment.WebRootPath, dirArchive);
                string pubType = (fileName.Contains("FASB", StringComparison.OrdinalIgnoreCase)) ? "FASB" : "GASB";
                string _category = (fileName.Contains("compare", StringComparison.OrdinalIgnoreCase)) ? "compare" : "complete";

                // Define a dictionary to map pubType and _category values to view names
                var viewMappings = new Dictionary<(string PubType, string Category), string>
                {
                    { ("FASB", "compare"), "fasbcompare" },
                    { ("FASB", "complete"), "fasbcomplete" },
                    { ("GASB", "compare"), "gasbcompare" },
                    { ("GASB", "complete"), "gasbcomplete" }
                };

                // Look up the view name based on pubType and _category
                if (viewMappings.TryGetValue((pubType, _category), out var mappedView))
                {
                    view = mappedView;
                }
                else
                {
                    // Default view name if there's no mapping
                    view = "fasbcompare";
                }


                //if (pubType == "FASB" && _category == "compare")
                //    view = "fasbcompare";
                //if (pubType == "FASB" && _category == "complete")
                //    view = "fasbcomplete";
                //if (pubType == "GASB" && _category == "compare")
                //    view = "gasbcompare";
                //if (pubType == "GASB" && _category == "compare")
                //    view = "gasbcomplete";

                try
                {
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
                catch (DbUpdateConcurrencyException ex)
                {

                    throw;
                }
            }

            ViewBag.UploadMsg += string.Format("File upload was <b>successful</b>.<br />");
            foreach (string fileName in lstUploadedFiles)
            {
                ViewBag.UploadMsg += string.Format("<b>{0}</b> was uploaded.<br />", fileName);
            }


            string actionName;

            switch (view)
            {
                case "fasbcompare":
                    actionName = "FASBCompare";
                    break;
                case "fasbcomplete":
                    actionName = "FASBComplete";
                    break;
                case "gasbcompare":
                    actionName = "GASBCompare";
                    break;
                default:
                    actionName = "GASBComplete";
                    break;
            }

            return RedirectToAction(actionName);
        }


        public IActionResult Download(string FileName)
        {
            string fileDir = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
            string filePath = Path.Combine(Environment.WebRootPath, fileDir, FileName);

            return PhysicalFile(filePath, MimeTypes.GetMimeType(filePath), FileName);
        }

        public async Task<IActionResult> Delete(string FileName, string view)
        {
            string fileDir = Configuration.GetSection("DirectorySettings")["ArchivesDirectory"];
            string filePath = Path.Combine(Environment.WebRootPath, fileDir, FileName);

            System.IO.File.Delete(filePath);
            dbContext.tReports.Where(a => a.FileName == FileName && a.IsDeleted == false).FirstOrDefault().IsDeleted = true;
            dbContext.SaveChanges();

            ViewBag.Status = $"{FileName} was deleted successsfully.";

            string actionName = "";
            var query = dbContext.tReports.Where(a => a.IsDeleted == false);

            switch (view)
            {
                case "fasbcompare":
                    actionName = "FASBCompare";
                    query = query.Where(a => a.PubType == "FASB" && a.Category == "compare");
                    break;
                case "fasbcomplete":
                    actionName = "FASBComplete";
                    query = query.Where(a => a.PubType == "FASB" && a.Category == "complete");
                    break;
                case "gasbcompare":
                    actionName = "GASBCompare";
                    query = query.Where(a => a.PubType == "GASB" && a.Category == "compare");
                    break;
                default:
                    actionName = "GASBComplete";
                    query = query.Where(a => a.PubType == "GASB" && a.Category == "complete");
                    break;
            }

            var result = await query.OrderByDescending(a => a.DateCreated).ToListAsync();
            return View(actionName, result);
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
