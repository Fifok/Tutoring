﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutoring.Models.Db.Models
{
 [NotMapped]
    public class Page
    {
        public int Id { get; set; }
        public int TutorialId { get; set; }
        public virtual Tutorial Tutorial { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ContentItem> Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int PageNumber { get; set; }
    }
}