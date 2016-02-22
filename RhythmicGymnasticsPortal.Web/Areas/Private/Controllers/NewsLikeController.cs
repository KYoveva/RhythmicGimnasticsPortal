namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Services.Data;

    [Authorize]
    public class NewsLikeController : BaseController
    {
        private NewsLikesService likes;

        public NewsLikeController(UsersService users, NewsLikesService likes)
            : base(users)
        {
            this.likes = likes;
        }

        [HttpPost]
        public ActionResult Like(int newsId, int likeType)
        {
            var userId = this.CurrentUser.Id;
            var like = this.likes.AllLikes().FirstOrDefault(x => x.AuthorId == userId && x.NewsId == newsId);
            if (like == null)
            {
                like = new NewsLike
                {
                    AuthorId = userId,
                    NewsId = newsId,
                    Type = (LikeType)likeType
                };
                this.likes.Add(like);
            }
            else
            {
                this.likes.Delete(like);
            }

           var newsLikes = this.likes.AllLikes()
                .Where(x => x.NewsId == newsId);

            if(newsLikes.Count() < 1)
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