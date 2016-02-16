﻿namespace RhythmicGymnasticsPortal.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IRhythmicGymnasticsPortalDbContext { 

        IDbSet<User> Users { get; set; }

        IDbSet<News> News { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}