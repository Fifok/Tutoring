namespace Tutoring.Models.Db.Models
{
    public class ContentItem
    {
        public int PageId { get; set; }
        public Page Page { get; set; }
        public string Content { get; set; }

    }
}