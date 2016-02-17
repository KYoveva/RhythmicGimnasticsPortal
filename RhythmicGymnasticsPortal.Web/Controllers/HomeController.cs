namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Web.Models.NewsModels;
    using PagedList;

    public class HomeController : Controller
    {
        private const int PageSize = 5;

        private INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetNewsPartial(int? page)
        {
            var newsData =
                this.newsService
                        .LatestNews()
                        .ProjectTo<NewsSimpleViewModel>();

            int pageNumber = page ?? 1;

            return this.PartialView("_SimpleNewsPartial", newsData.ToPagedList(pageNumber, PageSize));
        }

    }
}