using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class TutorialIndexViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public UserInfoViewModel Author { get; set; }
        public PageViewModel Page { get; set; }
        public int CurrentPageNumber { get; set; }
        public int TotalPageNumber { get; set; }

    }
}
