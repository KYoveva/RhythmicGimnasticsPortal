namespace RhythmicGymnasticsPortal.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface INewsCategoryService
    {
        IQueryable<NewsCategory> AllNewsCategories();

        IQueryable<NewsCategory> CategoryById(int id);

        NewsCategory AddCategory(NewsCategory toAdd);

        void Delete(int id);

        void Update(NewsCategory toUpdate);
    }
}
