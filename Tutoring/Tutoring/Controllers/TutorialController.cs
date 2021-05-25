using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Db;
using Tutoring.Models;
using Tutoring.Models.Db.Models;
using Tutoring.Models.TutorialM;
using TutoringLib;

namespace Tutoring.Controllers
{
    public class TutorialController : Controller
    {
        private readonly TutoringContext _context;

        public TutorialController(TutoringContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id,int pageNumber = 1)
        {

            var tutorial = _context.Tutorials.Include(x => x.Author).Include(x=>x.Pages).ThenInclude(x=>x.Content).FirstOrDefault(x => x.Id == id);
            if(tutorial == null)
            {
                return NotFound();
            }

             var data = new TutorialIndexViewModel
            {
                Title = tutorial.Title,
                Description = tutorial.Description,
                Author = new UserInfoViewModel { Fullname = tutorial.Author.Fullname, Nickname = tutorial.Author.Nickname },
                Page = tutorial.Pages.Select(x => new PageViewModel
                {
                    Title = x.Title,
                    Content = x.Content.Select(x=>new ContentItemViewModel
                    {
                        Content = x.Content,
                        ContentType = x.ContentType
                    }).ToArray()
                }).Skip(pageNumber-1).FirstOrDefault(),
                CurrentPageNumber = pageNumber,
                TotalPageNumber = tutorial.Pages.Count
            };

            return View(data);
        }

        public async Task<IActionResult> AjaxGetPageAsync(int id, int pageNumber)
        {
            var page = await GetPageAsync(id, pageNumber);
            return PartialView("_PageDisplayPartial", 
                new PageViewModel 
                { 
                    Title = page.Title, 
                    Content = page.Content.Select(x=>new ContentItemViewModel {Content = x.Content, ContentType = x.ContentType}).ToArray() 
                });
        }

        private async Task<Page> GetPageAsync(int id, int pageNumber)
        {
            var tut = await _context.Tutorials.Include(x=>x.Pages).ThenInclude(x=>x.Content).FirstOrDefaultAsync(x => x.Id == id);
            if (pageNumber > 0)
                return tut.Pages.Skip(pageNumber-1).FirstOrDefault();

            return tut.Pages.ElementAt(0);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAsync(TutorialAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = HttpContext.User.Identities.First().FindFirst(ClaimTypes.Email).Value;
                var tutorial = new Tutorial
                {
                    Title = model.Title,
                    Description = model.Description,
                    Author = _context.Users.FirstOrDefault(x => x.Email == email),
                };

                _context.Tutorials.Add(tutorial);
                await _context.SaveChangesAsync();

                return RedirectToAction("AddPage", new {tutorialId =  tutorial.Id});
            }

            return BadRequest(model);
        }

        public IActionResult AddPage(int tutorialId)
        {
            return View();
        }

       
    }
}
