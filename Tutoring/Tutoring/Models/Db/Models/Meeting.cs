using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutoring.Models.Db.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public int TutoringId { get; set; }
        public TutoringModel Tutoring { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public ICollection<UserMeeting> Users { get; set; }
    }
}