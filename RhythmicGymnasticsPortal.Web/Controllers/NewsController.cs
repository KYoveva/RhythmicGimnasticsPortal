using AutoMapper.QueryableExtensions;
using RhythmicGymnasticsPortal.Services.Data.Contracts;
using RhythmicGymnasticsPortal.Web.Models.NewsModels;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;

namespace RhythmicGymnasticsPortal.Web.Controllers
{
    public class NewsController : Controller
    {
        private const int PageSize = 3;

        private INewsService news;

        public NewsController(INewsService news)
        {
            this.news = news;
        }

        public ActionResult All(string sortOrder, int? page)
        {
            var news = this.news
                .AllNews()
                .ProjectTo<NewsListViewModel>();

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

        private IQueryable<NewsListViewModel> GetSorted(IQueryable<NewsListViewModel> allNews, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
            ViewBag.NameSortParm = sortOrder == "Title" ? "name_desc" : "Title";

            switch (sortOrder)
            {
                case "Title":
                    allNews = allNews.OrderBy(a => a.Title);
                    break;
                case "name_desc":
                    allNews = allNews.OrderByDescending(a => a.Title);
                    break;
                case "Date":
                    allNews = allNews.OrderBy(a => a.DateCreated);
                    break;
                default:
                    allNews = allNews.OrderByDescending(a => a.DateCreated);
                    break;
            }

            return allNews;
        }
    }
}