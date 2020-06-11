namespace Assignment1.Migrations
{
    using Assignment1.Domain;
    using Assignment1.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment1.Domain.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment1.Domain.ApplicationDbContext context)
        {
            var manager = new UserManager<AppUser>(new UserStore<AppUser>(new ApplicationDbContext()));

            var user = new AppUser()
            {
                UserName = "keemz",
                Email = "admin3@mymail.com",
                EmailConfirmed = true,
                FirstName = "Akeem",
                LastName = "Hendricks"

            };

            manager.Create(user, "password1");
        }
    }
}
