using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoring.Db;
using Tutoring.Models;
using Tutoring.Models.Db.Models;
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
        public IActionResult Index(int? id)
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
                Pages = tutorial.Pages.Select(x => new PageViewModel
                {
                    Title = x.Title,
                    Content = x.Content.Select(x=>new ContentItemViewModel
                    {
                        Content = x.Content,
                        ContentType = x.ContentType
                    }).ToArray()
                }).ToArray()
            };

            return View(data);
        }

        
    }
}
