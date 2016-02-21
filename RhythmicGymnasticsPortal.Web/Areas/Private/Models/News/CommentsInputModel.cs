namespace RhythmicGymnasticsPortal.Web.Area.Private.Models.News
{
    using Infrastructure;
    using RhythmicGymnasticsPortal.Models;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentsInputModel : IMapFrom<Comment>
    {
        public CommentsInputModel()
        {
        }

        public CommentsInputModel(int newsId)
        {
            this.NewsId = newsId;
        }

        [Required]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public int NewsId { get; set; }
    }
}