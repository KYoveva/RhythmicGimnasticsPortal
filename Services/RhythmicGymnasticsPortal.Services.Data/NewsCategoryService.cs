namespace RhythmicGymnasticsPortal.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using RhythmicGymnasticsPortal.Data.Repositories;

    public class NewsCategoryService : INewsCategoryService
    {
        private readonly IRepository<NewsCategory> categories;

        public NewsCategoryService(IRepository<NewsCategory> categories)
        {
            this.categories = categories;
        }


        public NewsCategory AddCategory(NewsCategory toAdd)
        {
            this.categories.Add(toAdd);
            this.categories.SaveChanges();

            return toAdd;
        }

        public IQueryable<NewsCategory> AllNewsCategories()
        {
            return this.categories.All();
        }

        public IQueryable<NewsCategory> CategoryById(int id)
        {
            return this.categories.All().Where(x => x.Id == id);
        }

        public void Delete(int id)
        {
            this.categories.Delete(id);
            this.categories.SaveChanges();
        }

        public void Update(NewsCategory toUpdate)
        {
            this.categories.Update(toUpdate);
            this.categories.SaveChanges();
        }
    }
}
