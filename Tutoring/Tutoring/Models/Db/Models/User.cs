using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - Birthdate.Year;
                if (Birthdate.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
        }
        public string Fullname
        {
            get
            {
                return $"{Firstname} {Lastname}";
            }
        }

        public virtual ICollection<Tutorial> CreatedTutorials { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<TutoringModel> CreatedTutorings { get; set; }
        public virtual ICollection<Lesson> CreatedLessons { get; set; }
        public virtual ICollection<Meeting> CreatedMeetings { get; set; }
        public virtual ICollection<UserMeeting> ParticipateMeetings { get; set; }
        public virtual ICollection<StudentTutoring> ParticipateTutorings { get; set; }
    }
}
