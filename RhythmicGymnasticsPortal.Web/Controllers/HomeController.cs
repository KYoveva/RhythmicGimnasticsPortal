namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.NewsModels;
    using Models.Products;
    using Services.Data.Contracts;
    using Services.Web.Contracts;

    public class HomeController : Controller
    {
        private const int TimeForCache = (5 * 60);

        private ICacheService cacheService;
        private INewsService newsService;
        private IProductsService productsService;

        public HomeController(INewsService newsService, IProductsService productsService, ICacheService cacheService)
        {
            this.newsService = newsService;
            this.productsService = productsService;
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

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetProductsPartial()
        {
            var productsData =
                this.cacheService.Get(
                    "Products",
                    () => this.productsService
                        .TopSelling()
                        .ProjectTo<ProductsSimpleViewModel>().ToList(),
                    TimeForCache);

            return this.PartialView("_SimpleProductsPartial", productsData);
        }
    }
}