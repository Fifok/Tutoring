namespace TutoringLib.Models
{
    public class Comment
    {
        public int UserId { get; set; }
        public virtual User Author { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
        public string Content { get; set; }

    }
}