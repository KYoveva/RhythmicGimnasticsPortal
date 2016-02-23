namespace RhythmicGymnasticsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<RhythmicGymnasticsPortalDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RhythmicGymnasticsPortalDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            if (!context.Roles.Any())
            {
                this.SeedRoles(context);
            }
            if (!context.Users.Any(x=>x.UserName=="admin"))
            {
                this.SeedUsers(context);
            }
        }

        private void SeedRoles(RhythmicGymnasticsPortalDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Name, new IdentityRole(GlobalConstants.AdminRole));
            context.SaveChanges();
        }

        private void SeedUsers(RhythmicGymnasticsPortalDbContext context)
        {
            var user = new User
            {
                Email = "admin@admin.com",
                UserName = "admin",
                FirstName = "Kristina",
                LastName = "Yoveva",
                Avatar = "https://upload.wikimedia.org/wikipedia/commons/f/f8/Kanaeva1.jpg"
            };

            this.userManager.Create(user, "admin123");
            this.userManager.AddToRole(user.Id, GlobalConstants.AdminRole);
        }
    }
}
