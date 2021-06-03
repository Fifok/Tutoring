using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models.Db.Models;

namespace Tutoring.Models
{
    public class UserProfileViewModel
    {
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public IEnumerable<TutorialListItemViewModel> CreatedTutorials { get; set; }
        public IEnumerable<TutoringListItemViewModel> CreatedTutorings { get; set; }

    }
}
