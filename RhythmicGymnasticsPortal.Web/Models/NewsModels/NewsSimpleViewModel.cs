namespace RhythmicGymnasticsPortal.Web.Models.NewsModels
{
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;

    public class NewsSimpleViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set;}
    }
}