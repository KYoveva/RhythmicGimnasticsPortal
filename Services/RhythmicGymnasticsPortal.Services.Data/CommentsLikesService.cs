namespace RhythmicGymnasticsPortal.Services.Data
{
    using System.Linq;
    using Contracts;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class CommentsLikesService : ICommentsLikesService
    {
        private IRepository<CommentLike> likes;

        public CommentsLikesService(IRepository<CommentLike> likes)
        {
            this.likes = likes;
        }

        public IQueryable<CommentLike> AllLikes()
        {
            return this.likes.All();
        }

        public IQueryable<CommentLike> LikeByComments(int id)
        {
            return this.likes.All()
                .Where(x => x.CommentId == id);
        }
    }
}
