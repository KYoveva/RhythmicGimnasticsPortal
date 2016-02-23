namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.Comments;
    using Models.NewsModels;
    using PagedList;
    using Services.Data.Contracts;

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

        public ActionResult All(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSortParm = string.IsNullOrEmpty(sortOrder) ? "Date" : string.Empty;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var news = this.news
                .AllNews()
                .ProjectTo<NewsDetailsViewModel>();

            if (!string.IsNullOrEmpty(searchString))
            {
                news = news.Where(s => s.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    news = news.OrderBy(n => n.Title);
                    break;
                case "name_desc":
                    news = news.OrderByDescending(n => n.Title);
                    break;
                case "Date":
                    news = news.OrderBy(n => n.DateCreated);
                    break;
                default:
                    news = news.OrderByDescending(n => n.DateCreated);
                    break;
            }

            int pageNumber = page ?? 1;

            return this.View(news.ToPagedList(pageNumber, PageSize));
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