namespace RhythmicGymnasticsPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        private ICollection<ProductImages> images;

        public Product()
        {
            this.images = new HashSet<ProductImages>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category ProductCategory { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int SoldQuantity { get; set; }

        public string Material { get; set; }

        public string Color { get; set; }

        public virtual ICollection<ProductImages> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
