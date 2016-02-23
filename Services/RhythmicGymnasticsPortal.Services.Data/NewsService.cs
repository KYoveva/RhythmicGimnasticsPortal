namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
    using System.Linq;
    using Common;
    using Contracts;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class NewsService : INewsService
    {
        private readonly IRepository<News> news;

        public NewsService(IRepository<News> news)
        {
            this.news = news;
        }

        public News AddNews(News toAdd)
        {
            toAdd.DateCreated = DateTime.UtcNow;
            this.news.Add(toAdd);
            this.news.SaveChanges();

            return toAdd;
        }

        public IQueryable<News> AllNews()
        {
            return this.news.All();                
        }

        public void Delete(int id)
        {
            this.news.Delete(id);
            this.news.SaveChanges();
        }

        public IQueryable<News> LatestNews()
        {
            return this.news.All()
                .OrderByDescending(x => x.DateCreated).Take(GlobalConstants.LatestNewsCount);
        }

        public IQueryable<News> NewsById(int id)
        {
            return this.news.All().Where(x => x.Id == id);
        }

        public void Update(News toUpdate)
        {
            this.news.Update(toUpdate);
            this.news.SaveChanges();
        }
    }
}
