namespace RhythmicGymnasticsPortal.Web.Areas.Administration.Models
{
    using RhythmicGymnasticsPortal.Models;
    using RhythmicGymnasticsPortal.Web.Infrastructure;

    public class NewsCategoriesViewModel : IMapFrom<NewsCategory>
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }
    }
}