namespace RhythmicGymnasticsPortal.Web.Areas.Private.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Web.Area.Private.Models.News;
    using Models.Comments;
    using Models.NewsModels;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class AddCommentController: Controller
    {
        private ICommentsService commentsService;
        private IUsersService usersService;

        public AddCommentController(ICommentsService commentsService, IUsersService usersService)
        {
            this.commentsService = commentsService;
            this.usersService = usersService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(CommentsInputModel model)
        { 
            var user = this.usersService.UserById(User.Identity.GetUserId());
            if (model != null && ModelState.IsValid)
            {
                var comment = Mapper.Map<Comment>(model);
                comment.AuthorId = user.Id;

                comment = this.commentsService.AddComment(comment);

                var viewModel = Mapper.Map<CommentsViewModel>(comment);
                viewModel.Avatar = user.Avatar;
                viewModel.Author = user.UserName;

                return this.PartialView("~/Areas/Private/Views/Comment/_SingleCommentPartial.cshtml", viewModel);
            }

            throw new HttpException(400, "Invalid Comment");
        }
    }
}