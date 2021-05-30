using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public int TutoringId { get; set; }
        public TutoringModel Tutoring { get; set; }
        public ICollection<ContentItem> Content { get; set; }
        public int Index { get; set; }
    }
}
