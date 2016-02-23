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
    public class ProductController : BaseController
    {
        private IProductsService products;

        public ProductController(IUsersService users, IProductsService products)
            : base(users)
        {
            this.products = products;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.products.AllProducts().ProjectTo<ProductsViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, ProductsViewModel product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Name=product.Name,
                    Description=product.Description,
                    Color=product.Color,
                    CategoryId=product.CategoryId,
                    Material=product.Material,
                    Price=product.Price,
                    Quantity=product.Quantity,
                    SoldQuantity=product.Quantity
                };

                this.products.AddProduct(entity);
                product.Id = entity.Id;
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, ProductsViewModel product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    SoldQuantity = product.SoldQuantity,
                    Material = product.Material,
                    Color = product.Color
                };

                this.products.Update(entity);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, ProductsViewModel product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    SoldQuantity = product.SoldQuantity,
                    Material = product.Material,
                    Color = product.Color
                };

                this.products.Delete(entity.Id);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
