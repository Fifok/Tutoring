using System.Collections.Generic;

namespace TutoringLib.Models
{
    public class Page
    {
        public int TutorialId { get; set; }
        public virtual Tutorial Tutorial { get; set; }
        public string Title { get; set; }
        public virtual ICollection<string> Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}