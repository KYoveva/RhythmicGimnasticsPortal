namespace RhythmicGymnasticsPortal.Web.Models.NewsModels
{
    using System;
    using AutoMapper;
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;

    public class NewsListViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<News, NewsListViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}