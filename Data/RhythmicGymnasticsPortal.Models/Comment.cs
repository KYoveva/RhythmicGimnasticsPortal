namespace RhythmicGymnasticsPortal.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
