namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.NewsModels;
    using PagedList;
    using Services.Data.Contracts;
    using Models.Comments;
    using RhythmicGymnasticsPortal.Models;

    public class NewsController : Controller
    {
        private const int PageSize = 10;

        private INewsService news;
        private ICommentsService comments;

        public NewsController(INewsService news, ICommentsService comments)
        {
            this.news = news;
            this.comments = comments;
        }

        public ActionResult All(int? page, string sortOrder)
        {
            var news = this.news
                .AllNews()
                .ProjectTo<NewsDetailsViewModel>();

            int pageNumber = page ?? 1;

            var sorted = this.GetSorted(news, sortOrder);

            return this.View(sorted.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult Details(int id)
        {
            var news = this.news
                .NewsById(id)
                .ProjectTo<NewsDetailsViewModel>()
                .FirstOrDefault();

            if (news == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Item not Found");
            }

            return this.View(news);
        }

        private IQueryable<NewsDetailsViewModel> GetSorted(IQueryable<NewsDetailsViewModel> allNews, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "Date" : string.Empty;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            switch (sortOrder)
            {
                case "Name":
                    allNews = allNews.OrderBy(n => n.Title);
                    break;
                case "name_desc":
                    allNews = allNews.OrderByDescending(n => n.Title);
                    break;
                case "Date":
                    allNews = allNews.OrderBy(n => n.DateCreated);
                    break;
                default:
                    allNews = allNews.OrderByDescending(n => n.DateCreated);
                    break;
            }

            return allNews;
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult _NewsCommentsPartial(int? page, int id)
        {
            var newsData =
                this.comments
                .CommentsByNews(id)
                .OrderByDescending(x => x.DateCreated)
                .ProjectTo<CommentsViewModel>();

            int pageNumber = page ?? 1;

            return this.View(newsData.ToPagedList(pageNumber, PageSize));
        }
    }
}