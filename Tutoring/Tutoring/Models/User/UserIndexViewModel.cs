using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class UserIndexViewModel
    {
        [Display(Name ="Imię i nazwisko")]
        public string Fullname { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
    }
}
