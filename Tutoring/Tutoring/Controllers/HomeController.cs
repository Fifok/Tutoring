﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Db;
using Tutoring.Models;
using TutoringLib;

namespace Tutoring.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TutoringContext _context;

        public HomeController(ILogger<HomeController> logger, TutoringContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var data = new HomeIndexViewModel
            {
                Tutorials = _context.Tutorials.Select(x => new TutorialListItemViewModel
                {
                    Id = x.Id,
                    Author = new UserInfoViewModel { Id = x.Id, Fullname = x.Author.Fullname, Nickname = x.Author.Nickname },
                    Title = x.Title,
                    Description = x.Description
                }).ToArray(),
                Tutorings = _context.Tutorings.Select(x => new TutoringListItemViewModel
                {
                    Id = x.Id,
                    Author = new UserInfoViewModel { Id = x.Id, Fullname = x.Teacher.Fullname, Nickname = x.Teacher.Nickname },
                    Title = x.Title,
                    Description = x.Description
                }).ToArray()
            };
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
