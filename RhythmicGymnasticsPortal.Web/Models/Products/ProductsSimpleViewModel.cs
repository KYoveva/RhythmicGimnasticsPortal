namespace RhythmicGymnasticsPortal.Web.Models.Products
{
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;

    public class ProductsSimpleViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}