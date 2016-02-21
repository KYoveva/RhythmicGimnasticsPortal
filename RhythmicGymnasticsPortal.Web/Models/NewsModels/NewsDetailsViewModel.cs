namespace RhythmicGymnasticsPortal.Web.Models.NewsModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Comments;
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;
    using System.Linq;

    public class NewsDetailsViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Author { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public int CommentsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<News, NewsDetailsViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m=>m.CommentsCount, opt=> opt.MapFrom(x=>x.Comments.Any() ? x.Comments.Count : 0))
                .ForMember(m=>m.Comments, opt => opt.MapFrom(x => x.Comments));
        }
    }
}