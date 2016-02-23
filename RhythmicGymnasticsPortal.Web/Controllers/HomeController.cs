namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.NewsModels;
    using Services.Data.Contracts;
    using Services.Web.Contracts;
    using System.Linq;

    public class HomeController : Controller
    {
        private const int TimeForCache = (5 * 60);

        private ICacheService cacheService;
        private INewsService newsService;

        public HomeController(INewsService newsService, ICacheService cacheService)
        {
            this.newsService = newsService;
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetNewsPartial()
        {
            var newsData =
                this.cacheService.Get(
                    "News",
                    () => this.newsService
                        .LatestNews()
                        .ProjectTo<NewsSimpleViewModel>().ToList(),
                    TimeForCache);

            return this.PartialView("_SimpleNewsPartial", newsData);
        }
    }
}