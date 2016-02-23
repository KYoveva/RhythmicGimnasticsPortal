namespace RhythmicGymnasticsPortal.Web.Areas.Private.Models.Users
{
    using System.Linq;
    using System.ComponentModel;
    using AutoMapper;
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;

    public class UsersViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string Avatar { get; set; }

        [DisplayName("Comments Made")]
        public int CommentsMade { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<User, UsersViewModel>()
               .ForMember(u => u.CommentsMade, opts => opts.MapFrom(u => u.Comments.Any() ? u.Comments.Count() : 0));
        }
    }
}