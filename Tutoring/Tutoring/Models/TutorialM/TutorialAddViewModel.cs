using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.TutorialM
{
    public class TutorialAddViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
