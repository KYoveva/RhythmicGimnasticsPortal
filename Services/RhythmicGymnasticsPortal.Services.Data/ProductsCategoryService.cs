﻿namespace RhythmicGymnasticsPortal.Services.Data
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

        public Category AddCategory(Category toAdd)
        {
            this.categories.Add(toAdd);
            this.categories.SaveChanges();

            return toAdd;
        }

        public IQueryable<Category> AllProductCategories()
        {
            return this.categories.All();
        }

        public IQueryable<Category> CategoryById(int id)
        {
            return this.categories.All().Where(x => x.Id == id);
        }

        public void Delete(int id)
        {
            this.categories.Delete(id);
            this.categories.SaveChanges();
        }

        public IQueryable<Product> ProductsByCategory(int id)
        {
            return this.categories
                .All()
                .Where(x => x.Id == id)
                .SelectMany(x => x.Products);
        }

        public void Update(Category toUpdate)
        {
            this.categories.Update(toUpdate);
            this.categories.SaveChanges();
        }
    }
}
