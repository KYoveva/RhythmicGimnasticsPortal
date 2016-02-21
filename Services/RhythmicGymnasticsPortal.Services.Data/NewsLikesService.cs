namespace RhythmicGymnasticsPortal.Services.Data
{
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

        public IQueryable<NewsLike> AllLikes()
        {
            return this.likes.All();
        }

        public IQueryable<NewsLike> LikeByNews(int id)
        {
            return this.likes.All()
                .Where(x => x.NewsId == id);
        }
    }
}
