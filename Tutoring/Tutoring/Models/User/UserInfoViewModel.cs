using System.ComponentModel.DataAnnotations;

namespace Tutoring.Models
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Imię i nazwisko")]
        public string Fullname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
    }
}