namespace RhythmicGymnasticsPortal.Web.Areas.Administration.Models
{
    using RhythmicGymnasticsPortal.Models;
    using Infrastructure;

    public class ProductsViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SoldQuantity { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public int CategoryId { get; set; }
    }
}