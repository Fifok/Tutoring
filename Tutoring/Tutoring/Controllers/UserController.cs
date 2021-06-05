using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tutoring.Db;
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

        [Authorize]
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
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if(user == null)
                {
                    return BadRequest("Wrong credentials");
                }
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Fullname),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme)));
                return RedirectToAction(nameof(Index),"Home");
            }

            return BadRequest();
        }

        public async Task<IActionResult> SignoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile(int id)
        {
            var user = _context.Users
                .Include(x=>x.CreatedTutorials)
                .Include(x=>x.CreatedTutorings)
                .FirstOrDefault(x => x.Id == id);
            var model = new UserProfileViewModel
            {
                Fullname = user.Fullname,
                Nickname = user.Nickname,
                Birthdate = user.Birthdate,
                Age = user.Age,
                CreatedTutorials = user.CreatedTutorials.Select(x => new TutorialListItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                }),
                CreatedTutorings = user.CreatedTutorings.Select(x => new TutoringListItemViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                })
            };
            return View(model);
        }
    }
}
