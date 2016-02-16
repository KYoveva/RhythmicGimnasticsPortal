namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Web.Models.NewsModels;

    public class HomeController : Controller
    {
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
        public ActionResult GetNewsPartial()
        {
            var newsData =
                this.newsService
                        .LatestNews()
                        .ProjectTo<NewsSimpleViewModel>();

            return this.PartialView("_SimpleNewsPartial", newsData);
        }

    }
}