namespace RhythmicGymnasticsPortal.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class NewsCategory
    {
        private ICollection<News> news;

        public NewsCategory()
        {
            this.news = new HashSet<News>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public virtual ICollection<News> News
        {
            get { return this.news; }
            set { this.news = value; }
        }
    }
}
