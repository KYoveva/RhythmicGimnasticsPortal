namespace RhythmicGymnasticsPortal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using Common;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

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
            //this.SeedRoles(context);
            //this.SeedUsers(context);
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
                UserName = "admin@admin.com",
                FirstName = "Kristina",
                LastName = "Yoveva"
            };

            this.userManager.Create(user, "admin123");
            this.userManager.AddToRole(user.Id, GlobalConstants.AdminRole);
        }
    }
}
