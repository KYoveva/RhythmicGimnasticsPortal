﻿namespace RhythmicGymnasticsPortal.Models
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<News> news;

        public User()
        {
            this.news = new HashSet<News>();       
        }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set;}

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string Avatar { get; set; }

        public virtual ICollection<News> News
        {
            get { return this.news; }
            set { this.news = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}