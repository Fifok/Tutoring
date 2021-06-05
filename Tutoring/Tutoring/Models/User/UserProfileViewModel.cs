using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models.Db.Models;

namespace Tutoring.Models
{
    public class UserProfileViewModel
    {
        [Display(Name = "Imię i nazwisko")]
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime Birthdate { get; set; }
        [Display(Name = "Wiek")]
        public int Age { get; set; }
        public IEnumerable<TutorialListItemViewModel> CreatedTutorials { get; set; }
        public IEnumerable<TutoringListItemViewModel> CreatedTutorings { get; set; }

    }
}
