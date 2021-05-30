using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class ImageItemViewModel: ContentItemViewModel
    {
        public IFormFile Image { get; set; }
    }
}
