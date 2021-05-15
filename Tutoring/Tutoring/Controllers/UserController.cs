using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Models;
using TutoringLib.Models;
using TutoringLib.Repositories;

namespace Tutoring.Controllers
{
    public class UserController : Controller
    {
        private IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetAll().Select(x => new UserIndexViewModel
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
        public IActionResult Signup(SignupViewModel model)
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
                _userRepository.Add(newUser);
                return Ok(newUser);
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
                return Ok(model);
            }

            return BadRequest();
        }
    }
}
