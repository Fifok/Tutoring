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
                    Lessons = tut.Lessons?.OrderBy(x=>x.Index).Select(x=>new LessonListItemViewModel
                    {
                        Id = x.Id,
                        Author = new UserInfoViewModel { Fullname = x.Author.Fullname, Nickname = x.Author.Nickname },
                        Title = x.Title,
                        Index = x.Index
                    })
                });
            }
            return BadRequest($"Wrong id: {id}");
        }

        public IActionResult Lesson(int tutoringId, int lessonId)
        {
            var lesson = _context.Tutorings
                .Include(x=>x.Lessons).ThenInclude(x=>x.Author)
                .Include(x=>x.Lessons).ThenInclude(x=>x.Content)
                .FirstOrDefault(x => x.Id == tutoringId)
                .Lessons.FirstOrDefault(x => x.Index == lessonId);

            var totalLessonNumber = _context.Tutorings.FirstOrDefault(x => x.Id == tutoringId)?.Lessons.Count();

            if (lesson != null)
            {
                return View(new LessonViewModel
                {
                    Title = lesson.Title,
                    Content = lesson.Content.OrderBy(x=>x.Index)
                        .Select(x=>new ContentItemViewModel { Content = x.Content,ContentType = x.ContentType}).ToArray(),
                    Description = lesson.Description,
                    Author = new UserInfoViewModel { Fullname = lesson.Author.Fullname, Nickname = lesson.Author.Nickname },
                    Index = lesson.Index,
                    CurrentLesson = lessonId,
                    TotalLessonNumber = totalLessonNumber.HasValue ? totalLessonNumber.Value : 0
                });
            }

            return BadRequest();
        }
    }
}
