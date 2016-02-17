namespace RhythmicGymnasticsPortal.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class RhythmicGymnasticsPortalDbContext : IdentityDbContext<User>, IRhythmicGymnasticsPortalDbContext
    {
        public RhythmicGymnasticsPortalDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<News> News { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static RhythmicGymnasticsPortalDbContext Create()
        {
            return new RhythmicGymnasticsPortalDbContext();
        }
    }
}
