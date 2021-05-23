using System.Collections.Generic;
using Tutoring.Models.Db.Models;

namespace Tutoring.Models
{
    public class PageViewModel
    {
        public string Title { get; set; }
        public ICollection<ContentItemViewModel> Content { get; set; }
    }
}