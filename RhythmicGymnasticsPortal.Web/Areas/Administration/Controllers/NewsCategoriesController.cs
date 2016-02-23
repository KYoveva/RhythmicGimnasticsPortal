namespace RhythmicGymnasticsPortal.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using RhythmicGymnasticsPortal.Models;
    using Services.Data.Contracts;
    using Web.Controllers;

    [Authorize(Roles = "Admin")]
    public class NewsCategoriesController : BaseController
    {
        private INewsCategoryService newsCategries;

        public NewsCategoriesController(IUsersService users, INewsCategoryService newsCategries)
            : base(users)
        {
            this.newsCategries = newsCategries;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewsCategories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.newsCategries
                .AllNewsCategories()
                .ProjectTo<NewsCategoriesViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NewsCategories_Create([DataSourceRequest]DataSourceRequest request, NewsCategoriesViewModel newsCategory)
        {
            if (ModelState.IsValid)
            {
                var entity = new NewsCategory
                {
                    CategoryName = newsCategory.CategoryName
                };

                this.newsCategries.AddCategory(entity);
                newsCategory.Id = entity.Id;
            }

            return Json(new[] { newsCategory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NewsCategories_Update([DataSourceRequest]DataSourceRequest request, NewsCategoriesViewModel newsCategory)
        {
            if (ModelState.IsValid)
            {
                var entity = new NewsCategory
                {
                    CategoryName = newsCategory.CategoryName
                };

                this.newsCategries.Update(entity);
            }

            return Json(new[] { newsCategory }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NewsCategories_Destroy([DataSourceRequest]DataSourceRequest request, NewsCategoriesViewModel newsCategory)
        {
            if (ModelState.IsValid)
            {
                var entity = new NewsCategory
                {
                    CategoryName = newsCategory.CategoryName
                };

                this.newsCategries.Delete(entity.Id);
            }

            return Json(new[] { newsCategory }.ToDataSourceResult(request, ModelState));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
