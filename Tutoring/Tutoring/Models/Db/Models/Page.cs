using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoringLib.Models
{
    [NotMapped]
    public class Page
    {
        public int Id { get; set; }
        public int TutorialId { get; set; }
        public virtual Tutorial Tutorial { get; set; }
        public string Title { get; set; }
        public virtual ICollection<string> Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}