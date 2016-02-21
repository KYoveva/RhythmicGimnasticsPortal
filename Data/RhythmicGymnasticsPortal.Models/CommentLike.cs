namespace RhythmicGymnasticsPortal.Models
{
    public class CommentLike
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comments { get; set; }

        public LikeType Type { get; set; }
    }
}
