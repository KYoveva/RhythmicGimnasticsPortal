namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface ICommentService
    {
        IQueryable<Comment> AllComments();

        IQueryable<Comment> CommentsByNews(int id);

        Comment AddComment(Comment toAdd);
    }
}
