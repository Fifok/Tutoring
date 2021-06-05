using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.TutoringVM
{
    public class LessonViewModel
    {
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public UserInfoViewModel Author { get; set; }
        public ICollection<ContentDisplayItemViewModel> Content { get; set; }
        public int Index { get; set; }
        public int CurrentLesson { get; set; }
        public int TotalLessonNumber { get; set; }
    }
}
