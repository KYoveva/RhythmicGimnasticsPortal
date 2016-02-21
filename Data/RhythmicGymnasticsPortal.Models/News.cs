namespace RhythmicGymnasticsPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class News
    {
        private ICollection<Comment> comments;
        private ICollection<NewsLike> likes;

        public News()
        {
            this.comments = new HashSet<Comment>();
            this.likes = new HashSet<NewsLike>();
        }     

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public string CategoryId { get; set; }

        public virtual NewsCategory Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<NewsLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}
