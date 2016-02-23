namespace RhythmicGymnasticsPortal.Web.Areas.Administration.Models
{
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;

    public class ProductCategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}