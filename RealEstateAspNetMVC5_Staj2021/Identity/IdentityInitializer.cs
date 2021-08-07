using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstateAspNetMVC5_Staj2021.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }
            //We can add roles like this here 
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }

            //Süper Adminin bilgilerini otomatik eklenir  database'e

            if (!context.Users.Any(i => i.Name == "Nermin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Nermin", Surname = "ŞAAR", UserName = "nermin", Email = "nermin@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }

            // Normal kullanıcı otomatik eklenir burda sadece bir kullanıcı eklenmesini istedim
            if (!context.Users.Any(i => i.Name == "Marah"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Marah", Surname = "Şaar", UserName = "marah", Email = "marah@gmail.com" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");

            }
            base.Seed(context);
        }


    }
}