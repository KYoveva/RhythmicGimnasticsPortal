namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface ICommentsLikesService
    {
        IQueryable<CommentLike> AllLikes();

        CommentLike LikeByComments(int id);

        CommentLike Add(CommentLike toAdd);

        CommentLike Delete(CommentLike toDelete);
    }
}
