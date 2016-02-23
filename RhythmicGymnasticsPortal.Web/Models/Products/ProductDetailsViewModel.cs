namespace RhythmicGymnasticsPortal.Web.Models.Products
{
    using System;
    using AutoMapper;
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Web.Infrastructure;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductDetailsViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public IList<string> Images { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductDetailsViewModel>()
               .ForMember(m => m.Category, opt => opt.MapFrom(x => x.ProductCategory.Name))
               .ForMember(m=>m.Images, opt => opt.MapFrom(x=>x.Images.Select(i=>i.Url)));
        }
    }
}