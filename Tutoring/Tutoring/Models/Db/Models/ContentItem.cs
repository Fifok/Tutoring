namespace Tutoring.Models.Db.Models
{
    public class ContentItem
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
    }
    
    public enum ContentType
    {
        Text,
        Image
    }
}