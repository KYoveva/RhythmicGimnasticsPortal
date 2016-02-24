namespace RhythmicGymnasticsPortal.Web.Models.Comments
{
    using System;
    using AutoMapper;
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Web.Infrastructure;
    using System.Linq;

    public class CommentsViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string Avatar { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public int NewsId { get; set; }

        public int LikesCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentsViewModel>()
               .ForMember(r => r.Avatar, opts => opts.MapFrom(x => x.Author.Avatar))
               .ForMember(r => r.Author, opts => opts.MapFrom(x => x.Author.UserName))
               .ForMember(r=>r.LikesCount, opts => opts.MapFrom(x=>x.Likes.Any() ? x.Likes.Sum(t => (int)t.Type) : 0));
        }
    }
}