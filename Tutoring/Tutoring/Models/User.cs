﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutoring.Models
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
