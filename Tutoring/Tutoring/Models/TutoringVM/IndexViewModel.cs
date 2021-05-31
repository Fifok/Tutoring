using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.TutoringVM
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserInfoViewModel Teacher { get; set; }
        public IEnumerable<LessonListItemViewModel> Lessons { get; set; }
        public IEnumerable<UserInfoViewModel> Students { get; set; }
    }
}
