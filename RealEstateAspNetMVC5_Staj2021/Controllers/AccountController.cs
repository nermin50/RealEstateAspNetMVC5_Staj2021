﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RealEstateAspNetMVC5_Staj2021.Identity;
using RealEstateAspNetMVC5_Staj2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;

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

        public ActionResult HosGeldin()
        {
            return View();
        }
        public ActionResult Login()
        {
           
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model, string ReturnURl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    // Session Close or Not Rememeber me 
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    // Authentication of pages
                    if (!String.IsNullOrEmpty(ReturnURl))
                    {
                        return Redirect(ReturnURl);
                    }
                    //after Login 
                    return RedirectToAction("HosGeldin", "Account");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulamadı");
                    return RedirectToAction("Login", "Account");

                }

            }
            return View(model);
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

       public ActionResult LogOut()
        {
            var auth = HttpContext.GetOwinContext().Authentication;
            auth.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}