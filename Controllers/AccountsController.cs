using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNTADSpreadsheets.Controllers
{
    [Authorize]
	public class AccountsController : Controller
	{
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly AppDBContext dbContext;

        public AccountsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDBContext db)
        {
            dbContext = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
		{
            var users = (from user in dbContext.Users
                         select new
                         {
                             UserId = user.Id,
                             Username = user.UserName,
                             Email = user.Email,
                             Role = user.Role,
                             FirstName = user.FirstName,
                             LastName = user.LastName
                         }).ToList().Select(p => new SignUpModel()
                         {
                             EmailAddress = p.Username,
                             Role = p.Role,
                             FirstName = p.FirstName,
                             LastName = p.LastName
                         });
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SignUpModel user, string userRole)
        {
            if (ModelState.IsValid)
            {
                string roleID = "1";    //USER
                if(userRole == "ADMIN")
				{
                    roleID = "2";
                }

                var userIdentity = new AppUser
                {
                    UserName = user.EmailAddress,
                    Email = user.EmailAddress,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = userRole,
                    RoleId = roleID
                };
                var result = await userManager.CreateAsync(userIdentity, user.Password);

                if (result.Succeeded)
                {
                    ViewBag.SignUpSuccess = "Registration successful.";
                    ModelState.Clear();

                    return View();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    ViewBag.ModelError = "On";
                    return View(user);
                }
            }

            else //model validation
            {
                return View(user);
            }
        }

        public IActionResult Update(string emailAdd)
        {
            var user = dbContext.Users.Where(a => a.Email == emailAdd).FirstOrDefault();
            var userModel = new UpdateUserModel
            {
                UserId = user.Id,
                EmailAddress = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role
            };

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserModel user)
        {
            if (ModelState.IsValid)
            {
                string roleID = user.Role == "USER" ? "1" : "2";

                var userUpdate = await userManager.FindByEmailAsync(user.EmailAddress);

                userUpdate.FirstName = user.FirstName;
                userUpdate.LastName = user.LastName;
                userUpdate.Role = user.Role;
                userUpdate.RoleId = roleID;

				var result = await userManager.UpdateAsync(userUpdate);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    ViewBag.State = "An error occured.";
                    return View(user);
                }
                                
            }

            else //model validation
            {
                ViewBag.State = "An error occured.";
                return View(user);
            }
        }

        public IActionResult ResetPassword(string emailAdd)
        {
            var user = dbContext.Users.Where(a => a.Email == emailAdd).FirstOrDefault();
            var userModel = new ResetPasswordModel
            {
                UserId = user.Id,
                EmailAddress = user.Email,
                Password = user.PasswordHash
            };

            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel user)
        {
            if (ModelState.IsValid)
			{
                var userUpdate = await userManager.FindByEmailAsync(user.EmailAddress);

                string resetToken = await userManager.GeneratePasswordResetTokenAsync(userUpdate);
				var resetPassResult = await userManager.ResetPasswordAsync(userUpdate, resetToken, user.Password);

				if (!resetPassResult.Succeeded)
				{
                    foreach (var error in resetPassResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    ViewBag.State = "An error occured.";
					return View(user);
				}
                else
				{
                    return RedirectToAction("Index");
                }
			}
            else //model validation
            {
                ViewBag.State = "An error occured.";
                return View(user);
            }
        }

        public IActionResult Delete(string emailAdd)
        {
            var userDelete = dbContext.Users.Where(a => a.Email == emailAdd).FirstOrDefault();
            dbContext.Users.Remove(userDelete);
            dbContext.SaveChanges();

            ViewBag.Status = $"{emailAdd} was deleted successsfully.";

            var users = (from user in dbContext.Users
                         select new
                         {
                             UserId = user.Id,
                             Username = user.UserName,
                             Email = user.Email,
                             Role = user.Role,
                             FirstName = user.FirstName,
                             LastName = user.LastName
                         }).ToList().Select(p => new SignUpModel()
                         {
                             EmailAddress = p.Username,
                             Role = p.Role,
                             FirstName = p.FirstName,
                             LastName = p.LastName
                         });
            return View("Index", users);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
