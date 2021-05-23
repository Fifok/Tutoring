using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Content = MakePageContent(x)
                }).ToArray()
            };

            return View(data);
        }

        private string MakePageContent(Page page)
        {
            var sb = new StringBuilder();
            foreach (var contentItem in page.Content)
            {
                sb.Append(contentItem.Content);
            }
            return sb.ToString();
        }
    }
}
