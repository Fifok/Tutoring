using DynamicVML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.TutoringVM
{
    public class AddLessonViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual DynamicList<ContentItemViewModel> Content { get; set; } = new DynamicList<ContentItemViewModel>();
    }
}
