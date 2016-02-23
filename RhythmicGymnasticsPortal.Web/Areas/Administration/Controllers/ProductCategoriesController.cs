using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RhythmicGymnasticsPortal.Models;
using RhythmicGymnasticsPortal.Web.Controllers;
using RhythmicGymnasticsPortal.Services.Data.Contracts;
using RhythmicGymnasticsPortal.Web.Areas.Administration.Models;
using AutoMapper.QueryableExtensions;

namespace RhythmicGymnasticsPortal.Web.Areas.Administration
{
    [Authorize(Roles = "Admin")]
    public class ProductCategoriesController : BaseController
    {
        private IProductsCategoryService categories;

        public ProductCategoriesController(IUsersService users, IProductsCategoryService categories)
            : base(users)
        {
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.categories.AllProductCategories()
                .ProjectTo<ProductCategoriesViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Create([DataSourceRequest]DataSourceRequest request, ProductCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Name = category.Name
                };

                this.categories.AddCategory(entity);
                category.Id = entity.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Update([DataSourceRequest]DataSourceRequest request, ProductCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };

                this.categories.Update(entity);
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Categories_Destroy([DataSourceRequest]DataSourceRequest request, ProductCategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var entity = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };

                this.categories.Delete(entity.Id);
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
