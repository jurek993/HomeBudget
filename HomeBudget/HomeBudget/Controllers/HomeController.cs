using HomeBudget.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HomeBudget.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeController()
            : this(Startup.UserManagerFactory.Invoke())
        {
        }

        public HomeController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(ContainterViewModels containerModel)
        {
            if (containerModel.LoginModel != null)
            {
                return View();
            }
            else if (containerModel.RegisterModel != null)
            {
                var user = new AppUser
                {
                    UserName = containerModel.RegisterModel.Email,
                    Email = containerModel.RegisterModel.Email

                };
                var result = await _userManager.CreateAsync(user, containerModel.RegisterModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Information", "Info", new { text = "RegisterConfirm" });
                }
                string temp;
                Regex regex = new Regex(@"Name .* is already taken.");
                foreach (var error in result.Errors)
                {
                    temp = error;
                    if (error == "Passwords must be at least 6 characters.")
                    {
                        temp = "Hasło musi zawierać przynajmniej 6 znaków.";
                    }
                    if (regex.Match(error).Success)
                    {
                        temp = "Istnieje konto dla podanego adresu email.";
                    }
                    ModelState.AddModelError("", temp);
                }

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}