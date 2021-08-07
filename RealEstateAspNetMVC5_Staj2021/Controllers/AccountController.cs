using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RealEstateAspNetMVC5_Staj2021.Identity;
using RealEstateAspNetMVC5_Staj2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstateAspNetMVC5_Staj2021.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }



        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.Username;
                user.Surname = model.Surname;
                user.Email = model.Email;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {

                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıccı oluşturma hatası");
                }
            }
            return View(model);
        }



        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}