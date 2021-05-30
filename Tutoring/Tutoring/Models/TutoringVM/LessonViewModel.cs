using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.TutoringVM
{
    public class LessonViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserInfoViewModel Author { get; set; }
        public ICollection<ContentItemViewModel> Content { get; set; }
    }
}
