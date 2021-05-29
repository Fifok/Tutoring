using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class StudentTutoring
    {
        public int TutoringId { get; set; }
        public TutoringModel Tutoring { get; set; }
        public int StudentId { get; set; }
        public User Student { get; set; }
    }
}
