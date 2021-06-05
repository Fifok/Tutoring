﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.TutoringVM
{
    public class IndexViewModel
    {
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public UserInfoViewModel Teacher { get; set; }
        public IEnumerable<LessonListItemViewModel> Lessons { get; set; }
        public IEnumerable<UserInfoViewModel> Students { get; set; }
    }
}
