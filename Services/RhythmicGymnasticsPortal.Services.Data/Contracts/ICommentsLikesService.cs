namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface ICommentsLikesService
    {
        IQueryable<CommentLike> AllLikes();

        IQueryable<CommentLike> LikeByComments(int id);
    }
}
