namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface INewsService
    {
        IQueryable<News> AllNews();

        IQueryable<News> LatestNews();

        IQueryable<News> NewsById(int id);

        News AddNews(News toAdd);
    }
}
