using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Db;
using Tutoring.Models;
using Tutoring.Models.TutoringVM;

namespace Tutoring.Controllers
{
    public class TutoringController : Controller
    {
        private readonly TutoringContext _context;

        public TutoringController(TutoringContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id = 0)
        {
            var tut = _context.Tutorings.Include(x=>x.Teacher).Include(x=>x.Lessons).FirstOrDefault(x => x.Id == id);
            if (tut != null)
            {
                return View(new Models.TutoringVM.IndexViewModel
                {
                    Title = tut.Title,
                    Teacher = new UserInfoViewModel { Nickname = tut.Teacher.Nickname, Fullname = tut.Teacher.Fullname },
                    Description = tut.Description,
                    Lessons = tut.Lessons?.Select(x=>new LessonListItemViewModel
                    {
                        Id = x.Id,
                        Author = new UserInfoViewModel { Fullname = x.Author.Fullname, Nickname = x.Author.Nickname },
                        Title = x.Title
                    })
                });
            }
            return BadRequest($"Wrong id: {id}");
        }
    }
}
