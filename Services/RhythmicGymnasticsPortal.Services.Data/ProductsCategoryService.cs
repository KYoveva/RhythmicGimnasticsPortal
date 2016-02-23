namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
    using System.Linq;
    using Models;
    using RhythmicGymnasticsPortal.Services.Data.Contracts;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class ProductsCategoryService : IProductsCategoryService
    {
        private IRepository<Category> categories;

        public ProductsCategoryService(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Product> ProductsByCategory(int id)
        {
            return this.categories
                .All()
                .Where(x => x.Id == id)
                .SelectMany(x => x.Products);
        }
    }
}
