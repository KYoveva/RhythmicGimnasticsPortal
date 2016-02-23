namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using PagedList;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Web.Models.Products;

    public class ProductsController : BaseController
    {
        private const int PageSize = 10;

        private readonly IProductsService products;

        public ProductsController(IUsersService users, IProductsService products)
            : base(users)
        {
            this.products = products;
        }

        public ActionResult All(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.PriceSortParm = string.IsNullOrEmpty(sortOrder) ? "Price" : string.Empty;
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

            var products = this.products
                .AllProducts()
                .ProjectTo<ProductDetailsViewModel>();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Name":
                    products = products.OrderBy(n => n.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(n => n.Name);
                    break;
                case "Price":
                    products = products.OrderBy(n => n.Price);
                    break;
                default:
                    products = products.OrderByDescending(n => n.Price);
                    break;
            }

            int pageNumber = page ?? 1;

            return this.View(products.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult Details(int id)
        {
            var products = this.products
                .AllProducts()
                .Where(x=>x.Id==id)
                .ProjectTo<ProductDetailsViewModel>()
                .FirstOrDefault();

            if (products == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Item not Found");
            }

            return this.View(products);
        }
    }
}