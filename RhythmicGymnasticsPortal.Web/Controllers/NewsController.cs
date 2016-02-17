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
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Date" : "";
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
    }
}