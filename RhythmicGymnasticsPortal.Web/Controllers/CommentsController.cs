namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Area.Private.Models.News;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.Comments;
    using PagedList;
    using RhythmicGymnasticsPortal.Models;
    using Services.Data.Contracts;
    using Models.NewsModels;

    public class CommentsController : BaseController
    {
        private const int PageSize = 10;

        private ICommentsService comments;
        private INewsService news;  

        public CommentsController(IUsersService users, ICommentsService comments, INewsService news)
            :base(users)
        {
            this.comments = comments;
            this.news = news;
        }

        public ActionResult AllCommentsByNews(string sortOrder, int? page, int id)
        {
            var comments = this.comments
                .CommentsByNews(id)
                .ProjectTo<CommentsViewModel>();

            int pageNumber = page ?? 1;

            var sorted = this.GetSorted(comments, sortOrder);

            return this.View(sorted.ToPagedList(pageNumber, PageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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

            throw new HttpException(400, "Invalid Comment");
        }

        private IQueryable<CommentsViewModel> GetSorted(IQueryable<CommentsViewModel> allComments, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "Date" : string.Empty;

            switch (sortOrder)
            {
                case "Date":
                    allComments = allComments.OrderBy(n => n.DateCreated);
                    break;
                default:
                    allComments = allComments.OrderByDescending(n => n.DateCreated);
                    break;
            }

            return allComments;
        }
    }
}