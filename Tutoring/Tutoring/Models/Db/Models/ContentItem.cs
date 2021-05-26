namespace Tutoring.Models.Db.Models
{
    public class ContentItem
    {
        public int Id { get; set; }

        public int TutorialId { get; set; }
        public Tutorial Tutorial { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
    }
    
    public enum ContentType
    {
        Text,
        Image
    }
}