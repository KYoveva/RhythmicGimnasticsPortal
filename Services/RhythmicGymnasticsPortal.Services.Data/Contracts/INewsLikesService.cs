namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;
    
    public interface INewsLikesService
    {
        IQueryable<NewsLike> AllLikes();

        NewsLike LikeByNews(int id);

        NewsLike Add(NewsLike toAdd);

        NewsLike Delete(NewsLike toDelete);
    }
}
