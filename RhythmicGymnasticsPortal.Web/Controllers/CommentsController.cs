namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Comments;
    using PagedList;
    using Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Models;
    using Microsoft.AspNet.Identity;
    using Area.Private.Models.News;

    public class CommentsController : Controller
    {
        private const int PageSize = 10;

        private ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
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