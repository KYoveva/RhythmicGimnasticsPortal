namespace RhythmicGymnasticsPortal.Models
{
    public class NewsLike
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public LikeType Type { get; set; }
    }
}
