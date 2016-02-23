namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IProductsService
    {
        IQueryable<Product> AllProducts();

        IQueryable<Product> TopSelling();

        Product ProductById(int id);

        Product AddProduct(Product toAdd);

        void Delete(int id);

        void Update(Product toUpdate);
    }
}
