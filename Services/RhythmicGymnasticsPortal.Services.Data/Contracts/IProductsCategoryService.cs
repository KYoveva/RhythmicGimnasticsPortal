namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IProductsCategoryService
    {
        IQueryable<Product> ProductsByCategory(int id);
    }
}
