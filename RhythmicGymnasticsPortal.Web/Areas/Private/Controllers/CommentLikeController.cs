namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using RhythmicGymnasticsPortal.Models;
    using Services.Data;

    public class CommentLikeController : BaseController
    {
        private CommentsLikesService likes;

        public CommentLikeController(UsersService users, CommentsLikesService likes)
            : base(users)
        {
            this.likes = likes;
        }

        [HttpPost]
        public ActionResult Like(int commentId, int likeType)
        {
            var userId = this.CurrentUser.Id;
            var like = this.likes.AllLikes().FirstOrDefault(x => x.AuthorId == userId && x.CommentId == commentId);
            if (like == null)
            {
                like = new CommentLike
                {
                    AuthorId = userId,
                    CommentId = commentId,
                    Type = (LikeType)likeType
                };
                this.likes.Add(like);
            }
            else
            {
                this.likes.Delete(like);
            }

            var newsLikes = this.likes.AllLikes()
                 .Where(x => x.CommentId == commentId);

            if (newsLikes.Count() < 1)
            {
                return this.Json(new { Count = 0 });
            }
            else
            {
                var count = newsLikes.Sum(x => (int)x.Type);
                return this.Json(new { Count = count });
            }
        }
    }
}