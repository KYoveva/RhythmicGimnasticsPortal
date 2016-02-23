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

        [UIHint("MultilineText")]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Author { get; set; }

        public string CategoryId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<News, NewsViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName));
        }
    }
}