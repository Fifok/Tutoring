using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models.Db.Models;

namespace Tutoring.Models
{
    public class ContentItemViewModel
    {
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
    }
}
