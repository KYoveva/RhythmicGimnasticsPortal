namespace RhythmicGymnasticsPortal.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IRhythmicGymnasticsPortalDbContext { 

        IDbSet<User> Users { get; set; }

        IDbSet<News> News { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<CommentLike> CommentLikes { get; set; }

        IDbSet<NewsCategory> NewsCategories { get; set; }

        IDbSet<NewsLike> NewsLikes { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}