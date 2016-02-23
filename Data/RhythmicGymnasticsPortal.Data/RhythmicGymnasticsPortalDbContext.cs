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

        public IDbSet<CommentLike> CommentLikes { get; set; }

        public IDbSet<NewsCategory> NewsCategories { get; set; }

        public IDbSet<NewsLike> NewsLikes { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public static RhythmicGymnasticsPortalDbContext Create()
        {
            return new RhythmicGymnasticsPortalDbContext();
        }
    }
}
