namespace RhythmicGymnasticsPortal.Web.Areas.Private.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using Area.Private.Models.News;
    using AutoMapper;
    using RhythmicGymnasticsPortal.Models;
    using Services.Data;
    using Web.Controllers;
    using Services.Data.Contracts;

    [Authorize]
    public class ProductBuyController : BaseController
    {
        private IProductsService products;

        public ProductBuyController(IUsersService users, IProductsService products)
            : base(users)
        {
            this.products = products;
        }
        [HttpPost]
        public ActionResult Buy(int productId, int quantity)
        {
            var product = this.products.ProductById(productId);
            if (product.Quantity < 1)
            {
                return this.Json(new { Count = 0 });
            }
            else
            {
                product.Quantity = product.Quantity - 1;
                product.SoldQuantity = product.SoldQuantity + 1;
                this.products.Update(product);
                return this.Json(new { Count = product.Quantity });
            }

        }
    }
}