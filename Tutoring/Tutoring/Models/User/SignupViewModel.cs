using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class SignupViewModel
    {
        [Display(Name ="Imię")]
        public string Firstname { get; set; }
        [Display(Name ="Nazwisko")]
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        [Display(Name ="Hasło")]
        public string Password { get; set; }

    }
}
