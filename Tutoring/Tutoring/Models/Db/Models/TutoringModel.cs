using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class TutoringModel
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public User Teacher { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<StudentTutoring> Students { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
    }
}
