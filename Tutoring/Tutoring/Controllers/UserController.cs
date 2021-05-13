using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models;

namespace Tutoring.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
