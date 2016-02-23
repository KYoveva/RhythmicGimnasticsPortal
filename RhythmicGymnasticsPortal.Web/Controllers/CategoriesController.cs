namespace RhythmicGymnasticsPortal.Web.Controllers
{
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using Models.Products;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using System.Linq;
    using PagedList;

    public class CategoriesController : BaseController
    {
        private const int PageSize = 10;

        private IProductsCategoryService categories;

        public CategoriesController(IUsersService users, IProductsCategoryService categories)
            : base(users)
        {
            this.categories = categories;
        }

        public ActionResult AllProductsByCategory(int id, string sortOrder, string currentFilter, string searchString, int? page)
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

            var products = this.categories
                .ProductsByCategory(id)
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

            return this.PartialView(products.ToPagedList(pageNumber, PageSize));
        }
    }
}