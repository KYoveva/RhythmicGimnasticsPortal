namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IProductsCategoryService
    {
        IQueryable<Product> ProductsByCategory(int id);

        IQueryable<Category> AllProductCategories();

        IQueryable<Category> CategoryById(int id);

        Category AddCategory(Category toAdd);

        void Delete(int id);

        void Update(Category toUpdate);
    }
}
