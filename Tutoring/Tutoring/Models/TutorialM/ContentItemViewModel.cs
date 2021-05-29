using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models.Db.Models;

namespace Tutoring.Models
{
    public class ContentItemViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public ContentType ContentType { get; set; }
    }
}
