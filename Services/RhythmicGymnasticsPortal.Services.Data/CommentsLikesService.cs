namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
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

        public CommentLike Add(CommentLike toAdd)
        {
            this.likes.Add(toAdd);
            this.likes.SaveChanges();
            return toAdd;
        }

        public IQueryable<CommentLike> AllLikes()
        {
            return this.likes.All();
        }

        public CommentLike Delete(CommentLike toDelete)
        {
            this.likes.Delete(toDelete);
            this.likes.SaveChanges();
            return toDelete;
        }

        CommentLike ICommentsLikesService.LikeByComments(int id)
        {
            return this.likes.All()
                .FirstOrDefault(x => x.CommentId == id);
        }
    }
}
