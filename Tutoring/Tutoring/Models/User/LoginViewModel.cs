using System.ComponentModel.DataAnnotations;

namespace Tutoring.Controllers
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}