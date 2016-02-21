namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.NewsModels;
    using PagedList;
    using Services.Data.Contracts;
    using Models.Comments;

    public class HomeController : Controller
    {
        private INewsService newsService;

        public HomeController(INewsService newsService)
        {
            this.newsService = newsService;
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
                this.newsService
                        .LatestNews()
                        .ProjectTo<NewsSimpleViewModel>();

            return this.PartialView("_SimpleNewsPartial", newsData);
        }
    }
}