﻿namespace RhythmicGymnasticsPortal.Web.Models.NewsModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Comments;
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;

    public class NewsDetailsViewModel : IMapFrom<News>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Author { get; set; }

        public IEnumerable<CommentsViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<News, NewsDetailsViewModel>()
                .ForMember(m => m.Author, opt => opt.MapFrom(x => x.Author.UserName))
                .ForMember(m => m.Comments, opt => opt.MapFrom(x => x.Comments));
        }
    }
}