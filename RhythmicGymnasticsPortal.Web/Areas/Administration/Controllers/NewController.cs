namespace RhythmicGymnasticsPortal.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Web.Controllers;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using Models;

    [Authorize(Roles = "Admin")]
    public class NewController : BaseController
    {
        private INewsService news;
        private ICommentsService comments;

        public NewController(IUsersService users, INewsService news, ICommentsService comments)
            :base(users)
        {
            this.news = news;
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News_Read([DataSourceRequest]DataSourceRequest request)
        {

            DataSourceResult result = this.news.AllNews().ProjectTo<NewsViewModel>()    
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News_Create([DataSourceRequest]DataSourceRequest request, News news)
        {
            if (ModelState.IsValid)
            {
                var entity = new News
                {
                    Title = news.Title,
                    Content = news.Content,
                    DateCreated = news.DateCreated,
                    CategoryId = news.CategoryId,
                    AuthorId = this.CurrentUser.Id
                };

                this.news.AddNews(entity);
                news.Id = entity.Id;
            }

            return Json(new[] { news }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News_Update([DataSourceRequest]DataSourceRequest request, News news)
        {
            if (ModelState.IsValid)
            {
                var entity = new News
                {
                    Id = news.Id,
                    Title = news.Title,
                    Content = news.Content,
                    DateCreated = news.DateCreated,
                    CategoryId = news.CategoryId
                };

                this.news.Update(entity);
            }

            return Json(new[] { news }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult News_Destroy([DataSourceRequest]DataSourceRequest request, News news)
        {
            if (ModelState.IsValid)
            {
                var entity = new News
                {
                    Id = news.Id,
                    Title = news.Title,
                    Content = news.Content,
                    DateCreated = news.DateCreated,
                    CategoryId = news.CategoryId
                };

                this.news.Delete(entity.Id);
            }

            return Json(new[] { news }.ToDataSourceResult(request, ModelState));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    this.news.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
