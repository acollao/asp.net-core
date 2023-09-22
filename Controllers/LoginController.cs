using Google.Authenticator;
using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Controllers
{
	public class LoginController : Controller
	{
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;

        public LoginController(UserManager<AppUser> userManager,
								SignInManager<AppUser> signInManager, IConfiguration configuration)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
            _configuration = configuration;
        }

		//public SignInManager<AppUser> SignInManager { get; }

		public IActionResult Index()
		{
			return View();
		}

        //[Authorize(Policy = "Require2FA")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginModel user, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.EmailAddress, user.Password, false, false);

                if (result == null)
                {
                    ViewBag.ModelError = "On";
                    ModelState.AddModelError("", "Invalid Login Attempt");
                    return View(user);
                }

                if (result.Succeeded)
                {
                    //await signInManager.SignInAsync(userIdentity, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    TempData["tempId"] = result.RequiresTwoFactor;
                    HttpContext.Session.SetString("username", user.EmailAddress);

                    GenerateQRCode();

                    return RedirectToAction("VerifyAuth");
                }
                else
                {
                    ViewBag.ModelError = "On";
                    ModelState.AddModelError("", "Invalid Login Attempt");
                    return View(user);
                }

            }
            else
            {
                return View(user);
            }
        }


        public void GenerateQRCode()
        {
            bool status = false;
            string username = HttpContext.Session.GetString("username");
            var googleAuthKey = _configuration["KeySettings:TwoFactorSecretCode"];
            string UserUniqueKey = (username + googleAuthKey);
            var twoFactorAuthenticator = new TwoFactorAuthenticator();
            var setupCode = twoFactorAuthenticator.GenerateSetupCode("lntadspreadsheet", username,
                Encoding.ASCII.GetBytes(UserUniqueKey));
            HttpContext.Session.SetString("UserUniqueKey", UserUniqueKey);
            HttpContext.Session.SetString("BarcodeImageUrl", setupCode.QrCodeSetupImageUrl);
            HttpContext.Session.SetString("SetupCode", setupCode.ManualEntryKey);
            ViewData["BarcodeImageUrl"] = setupCode.QrCodeSetupImageUrl;
            ViewData["SetupCode"] = setupCode.ManualEntryKey;
            ViewBag.BarcodeImageUrl = setupCode.QrCodeSetupImageUrl;
            ViewBag.SetupCode = setupCode.ManualEntryKey;
            string imageURL = setupCode.QrCodeSetupImageUrl;
            string manualKey = setupCode.ManualEntryKey;
            status = true;
            ViewData["Status"] = status;
            var res = new
            {
                imageURL,
                manualKey
            };
        }

        public ActionResult VerifyAuth()
        {
            return View();
        }

        public IActionResult EnableAuth()
        {
            bool status = false;
            string username = HttpContext.Session.GetString("username");
            var googleAuthKey = _configuration["KeySettings:TwoFactorSecretCode"];
            string UserUniqueKey = (username + googleAuthKey);
            var twoFactorAuthenticator = new TwoFactorAuthenticator();
            //var setupCode = twoFactorAuthenticator.GenerateSetupCode("lntadspreadsheet", username,
                //Encoding.ASCII.GetBytes(googleAuthKey));
            var setupCode = twoFactorAuthenticator.GenerateSetupCode("lntadspreadsheet.com", username, Encoding.ASCII.GetBytes(UserUniqueKey), 300);
            HttpContext.Session.SetString("UserUniqueKey", UserUniqueKey);
            HttpContext.Session.SetString("BarcodeImageUrl", setupCode.QrCodeSetupImageUrl);
            HttpContext.Session.SetString("SetupCode", setupCode.ManualEntryKey);
            ViewData["BarcodeImageUrl"] = setupCode.QrCodeSetupImageUrl;
            ViewData["SetupCode"] = setupCode.ManualEntryKey;
            ViewBag.BarcodeImageUrl = setupCode.QrCodeSetupImageUrl;
            ViewBag.SetupCode = setupCode.ManualEntryKey;
            string imageURL = setupCode.QrCodeSetupImageUrl;
            string manualKey = setupCode.ManualEntryKey;
            status = true;
            ViewData["Status"] = status;

            return View();
        }

        [HttpPost]
        public IActionResult TwoFactorAuthenticate(string otpcode)
        {
            try
            {
                var token = otpcode;
                TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
                string UserUniqueKey = HttpContext.Session.GetString("UserUniqueKey");
                bool isValid = TwoFacAuth.ValidateTwoFactorPIN(UserUniqueKey, token, false);

                if (isValid)
                {
                    HttpContext.Session.SetString("IsValidTwoFactorAuthentication", "true");
                    return RedirectToAction("Index", "Home");
                }
                ViewData["ErrorMessage"] = "Google Two Factor PIN is expired or wrong";
                ViewBag.ErrorMessage = "Google Two Factor PIN is expired or wrong";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View("VerifyAuth");
        }

    }
}
