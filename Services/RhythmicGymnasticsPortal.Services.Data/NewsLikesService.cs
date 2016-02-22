namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class NewsLikesService : INewsLikesService
    {
        private IRepository<NewsLike> likes;

        public NewsLikesService(IRepository<NewsLike> likes)
        {
            this.likes = likes;
        }

        public NewsLike Add(NewsLike toAdd)
        {
            this.likes.Add(toAdd);
            this.likes.SaveChanges();
            return toAdd;
        }

        public IQueryable<NewsLike> AllLikes()
        {
            return this.likes.All();
        }

        public NewsLike Delete(NewsLike toDelete)
        {
            this.likes.Delete(toDelete);
            likes.SaveChanges();
            return toDelete;
        }

        public NewsLike LikeByNews(int id)
        {
            return this.likes.All()
                .FirstOrDefault(x => x.NewsId == id);
        }
    }
}
