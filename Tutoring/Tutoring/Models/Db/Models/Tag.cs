﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models.Db.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TutorialTag> Tutorials { get; set; }
    }
}
