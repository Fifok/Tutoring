using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class TutorialTag
    {
        public int TutorialId { get; set; }
        public Tutorial Tutorial { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
