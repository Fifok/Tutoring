using System.ComponentModel.DataAnnotations.Schema;

namespace Tutoring.Models.Db.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
        public string Content { get; set; }

    }
}