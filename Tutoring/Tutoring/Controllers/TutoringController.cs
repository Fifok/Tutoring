using DynamicVML;
using DynamicVML.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tutoring.Db;
using Tutoring.Models;
using Tutoring.Models.Db.Models;
using Tutoring.Models.TutoringVM;

namespace Tutoring.Controllers
{
    public class TutoringController : Controller
    {
        private readonly IHostEnvironment _env;
        private readonly TutoringContext _context;

        public TutoringController(IHostEnvironment environment, TutoringContext context)
        {
            _env = environment;
            _context = context;
        }
        public IActionResult Index(int id = 0)
        {
            var tut = _context.Tutorings
                .Include(x => x.Teacher)
                .Include(x => x.Lessons).ThenInclude(x => x.Author)
                .Include(x => x.Students).ThenInclude(x => x.Student)
                .FirstOrDefault(x => x.Id == id);
            if (tut != null)
            {
                return View(new Models.TutoringVM.IndexViewModel
                {
                    Title = tut.Title,
                    Teacher = new UserInfoViewModel { Nickname = tut.Teacher.Nickname, Fullname = tut.Teacher.Fullname, Email = tut.Teacher.Email },
                    Description = tut.Description,
                    Lessons = tut.Lessons?.OrderBy(x => x.Index).Select(x => new LessonListItemViewModel
                    {
                        Id = x.Id,
                        Author = new UserInfoViewModel { Fullname = x.Author.Fullname, Nickname = x.Author.Nickname },
                        Title = x.Title,
                        Index = x.Index
                    }),
                    Students = tut.Students.Select(x => new UserInfoViewModel { Fullname = x.Student.Fullname, Nickname = x.Student.Nickname, Email = x.Student.Email })
                });
            }
            return BadRequest($"Wrong id: {id}");
        }

        [Authorize]
        public IActionResult Lesson(int tutoringId, int lessonId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == HttpContext.User.FindFirst(ClaimTypes.Email).Value);
            var tutoring = _context.Tutorings
                .Include(x=>x.Teacher)
                .Include(x=>x.Students).ThenInclude(x=>x.Student)
                .Include(x => x.Lessons).ThenInclude(x => x.Author)
                .Include(x => x.Lessons).ThenInclude(x => x.Content)
                .FirstOrDefault(x => x.Id == tutoringId);

            if (!tutoring.Students.Any(x => x.Student == user) && !(user.Id == tutoring.Teacher.Id)) 
            {
                return Unauthorized("You cannot get to this lesson, sorry");
            }

            var lesson = tutoring.Lessons.FirstOrDefault(x => x.Index == lessonId);

            var totalLessonNumber = _context.Tutorings.FirstOrDefault(x => x.Id == tutoringId)?.Lessons.Count();

            if (lesson != null)
            {
                return View(new LessonViewModel
                {
                    Title = lesson.Title,
                    Content = lesson.Content.OrderBy(x => x.Index)
                        .Select(x => new ContentDisplayItemViewModel { Content = x.Content, ContentType = x.ContentType }).ToArray(),
                    Description = lesson.Description,
                    Author = new UserInfoViewModel { Fullname = lesson.Author.Fullname, Nickname = lesson.Author.Nickname },
                    Index = lesson.Index,
                    CurrentLesson = lessonId,
                    TotalLessonNumber = totalLessonNumber.HasValue ? totalLessonNumber.Value : 0
                });
            }

            return BadRequest();
        }

        [Authorize]
        public IActionResult AddLesson(int tutoringId)
        {
            return View(new AddLessonViewModel());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddLessonAsync(AddLessonViewModel model, int tutoringId)
        {
            if (ModelState.IsValid)
            {
                var tutoring = await _context.Tutorings.Include(x => x.Lessons).FirstOrDefaultAsync(x => x.Id == tutoringId);
                var author = _context.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identities.First().FindFirst(ClaimTypes.Email).Value);
                var newLesson = new Lesson
                {
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content.Select(x =>
                    {
                        var item = new ContentItem
                        {

                            ContentType = x.ViewModel.ContentType
                        };
                        switch (item.ContentType)
                        {
                            case ContentType.Text:
                                item.Content = x.ViewModel.Content;
                                break;
                            case ContentType.Image:
                                item.Content = $"{Guid.NewGuid()}{Path.GetExtension(x.ViewModel.Image.FileName)}";
                                using (var stream = System.IO.File.Create(Path.Combine(_env.ContentRootPath, "wwwroot", "images", item.Content)))
                                {
                                    x.ViewModel.Image.CopyTo(stream);
                                }
                                break;
                            default:
                                break;
                        }
                        return item;
                    }).ToArray(),
                    Author = author,
                    Index = tutoring.Lessons.Count() + 1
                };
                tutoring.Lessons.Add(newLesson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Tutoring", new { id = tutoringId });
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AddText(AddNewDynamicItem parameters)
        {
            var content = new ContentItemViewModel();
            content.ContentType = ContentType.Text;
            return this.PartialView(content, parameters);
        }

        [Authorize]
        public async Task<IActionResult> AddImage(AddNewDynamicItem parameters)
        {
            var content = new ContentItemViewModel();
            content.ContentType = ContentType.Image;
            return this.PartialView(content, parameters);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ParticipateAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
            if (user != null)
            {
                var tut = await _context.Tutorings.Include(x => x.Students).ThenInclude(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
                if (!tut.Students.Any(x => x.StudentId == user.Id) && tut.Teacher != user)
                {
                    tut.Students.Add(new StudentTutoring { Student = user, Tutoring = tut });
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index", new { id = id });
            }
            return Unauthorized();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RejectAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));
            if (user != null)
            {
                var tut = await _context.Tutorings.Include(x => x.Students).ThenInclude(x => x.Student).FirstOrDefaultAsync(x => x.Id == id);
                if (tut.Students.Any(x => x.StudentId == user.Id))
                {
                    var student = tut.Students.FirstOrDefault(x => x.StudentId == user.Id);
                    tut.Students.Remove(student);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index", new { id = id });
            }
            return Unauthorized();
        }
    }
}
