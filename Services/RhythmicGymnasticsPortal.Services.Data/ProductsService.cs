namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class ProductsService : IProductsService
    {
        private const int TopSellingProducts = 5;

        private IRepository<Product> products;

        public ProductsService(IRepository<Product> products)
        {
            this.products = products;
        }

        public Product AddProduct(Product toAdd)
        {
            this.products.Add(toAdd);
            this.products.SaveChanges();

            return toAdd;
        }

        public IQueryable<Product> AllProducts()
        {
            return this.products.All();
        }

        public void Delete(int id)
        {
            this.products.Delete(id);
            this.products.SaveChanges();
        }

        public Product ProductById(int id)
        {
            return this.products.All()
                .FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Product> TopSelling()
        {
            return this.products.All()
                .OrderByDescending(x => x.SoldQuantity)
                .Take(TopSellingProducts);
        }

        public void Update(Product toUpdate)
        {
            this.products.Update(toUpdate);
            this.products.SaveChanges();
        }
    }
}
