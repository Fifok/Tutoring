using DynamicVML;
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
using DynamicVML;
using DynamicVML.Extensions;
using System.IO;
using Microsoft.Extensions.Hosting;

namespace Tutoring.Controllers
{
    public class TutorialController : Controller
    {
        private readonly IHostEnvironment _env;
        private readonly TutoringContext _context;

        public TutorialController(TutoringContext context, IHostEnvironment environment)
        {
            _env = environment;
            _context = context;
        }
        public IActionResult Index(int? id, int pageNumber = 1)
        {

            var tutorial = _context.Tutorials.Include(x => x.Author).Include(x => x.Content).FirstOrDefault(x => x.Id == id);
            if (tutorial == null)
            {
                return NotFound();
            }

            var data = new IndexViewModel
            {
                Title = tutorial.Title,
                Description = tutorial.Description,
                Author = new UserInfoViewModel { Fullname = tutorial.Author.Fullname, Nickname = tutorial.Author.Nickname },
                Content = tutorial.Content.Select(x => new ContentDisplayItemViewModel
                {
                    Content = x.Content,
                    ContentType = x.ContentType
                }).ToArray()
            };

            return View(data);
        }

        //public async Task<IActionResult> AjaxGetPageAsync(int id, int pageNumber)
        //{
        //    var page = await GetPageAsync(id, pageNumber);
        //    return PartialView("_PageDisplayPartial",
        //        new PageViewModel
        //        {
        //            Title = page.Title,
        //            Content = page.Content.Select(x => new ContentItemViewModel { Content = x.Content, ContentType = x.ContentType }).ToArray()
        //        });
        //}

        //private async Task<Page> GetPageAsync(int id, int pageNumber)
        //{
        //    var tut = await _context.Tutorials.Include(x => x.Content).FirstOrDefaultAsync(x => x.Id == id);
        //    if (pageNumber > 0)
        //        return tut.Pages.Skip(pageNumber - 1).FirstOrDefault();

        //    return tut.Pages.ElementAt(0);
        //}

        [Authorize]
        public IActionResult Add()
        {
            return View(new AddViewModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newTutorial = new Tutorial
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
                                item.Content = x.ViewModel.Image.FileName;
                                using (var fs = new FileStream(Path.Combine(_env.ContentRootPath, "images", item.Content), FileMode.Create))
                                {
                                    x.ViewModel.Image.CopyTo(fs);
                                }
                                break;
                            default:
                                break;
                        }
                        return item;
                    }).ToArray(),
                    Author = _context.Users.FirstOrDefault(x => x.Email == HttpContext.User.Identities.First().FindFirst(ClaimTypes.Email).Value)
                };
                _context.Tutorials.Add(newTutorial);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
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
    }
}
