namespace RhythmicGymnasticsPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Product> prodcts;

        public Category()
        {
            this.prodcts = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Product> Products
        {
            get { return this.prodcts; }
            set { this.prodcts = value; }
        }
    }
}
