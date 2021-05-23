using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class HomeIndexViewModel
    {
        public ICollection<TutorialListItemViewModel> Tutorials { get; set; }
    }
}
