namespace RhythmicGymnasticsPortal.Web.Areas.Administration.Models
{
    using System;
    using AutoMapper;
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;
    using System.ComponentModel.DataAnnotations;

    public class NewsViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<News, NewsViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m => m.Category, opt => opt.MapFrom(x => x.Category.CategoryName.ToString()));
        }
    }
}