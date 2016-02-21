namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;
    
    public interface INewsLikesService
    {
        IQueryable<NewsLike> AllLikes();

        IQueryable<NewsLike> LikeByNews(int id);
    }
}
