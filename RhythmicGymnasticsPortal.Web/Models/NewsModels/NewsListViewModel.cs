namespace RhythmicGymnasticsPortal.Web.Models.NewsModels
{
    using System;
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Web.Infrastructure;

    public class NewsListViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Contetnt { get; set; }

        public DateTime DateCreated { get; set; }
    }
}