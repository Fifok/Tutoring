using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models;
using Tutoring.Models.Db.Models;
using TutoringLib;
using TutoringLib.Repositories;

namespace Tutoring.Controllers
{
    public class UserController : Controller
    {
        private readonly TutoringContext _context;

        public UserController(TutoringContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.Select(x => new UserIndexViewModel
            {
                Fullname = x.Fullname,
                Birthdate = x.Birthdate,
                Age = x.Age
            });

            return View(users);
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignupAsync(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new User
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Nickname = model.Nickname,
                    Email = model.Email,
                    Password = model.Password
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest(ModelState);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }
    }
}
