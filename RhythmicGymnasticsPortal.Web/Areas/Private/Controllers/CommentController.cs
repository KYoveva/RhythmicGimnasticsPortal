namespace RhythmicGymnasticsPortal.Web.Areas.Private.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Area.Private.Models.News;
    using AutoMapper;
    using RhythmicGymnasticsPortal.Models;
    using Services.Data;
    using Web.Controllers;
    using Services.Data.Contracts;
    using Web.Models.Comments;
    using System.Linq;

    [Authorize]
    public class CommentController : BaseController
    {
        private ICommentsService comments;

        public CommentController(IUsersService users, ICommentsService comments)
            : base(users)
        {
            this.comments = comments;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentsInputModel model)
        {
            var user = this.CurrentUser;
            if (model != null && ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.AuthorId = user.Id;

                comment = this.comments.AddComment(comment);

                var viewModel = Mapper.Map<CommentsViewModel>(comment);
                viewModel.Avatar = user.Avatar;
                viewModel.Author = user.UserName;

                return this.PartialView("~/Areas/Private/Views/Comment/_SingleCommentPartial.cshtml", viewModel);
            }

            throw new HttpException(400, "Invalid comment");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var comment = this.comments.AllComments().FirstOrDefault(x => x.Id == id);
            if (comment != null)
            {
                this.comments.Delete(comment);
            }

                return this.Json(new { Count = comment });
        }
    }
}