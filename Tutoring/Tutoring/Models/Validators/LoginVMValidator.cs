﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutoring.Controllers;

namespace Tutoring.Models.Validators
{
    public class LoginVMValidator : AbstractValidator<LoginViewModel>
    {
        public LoginVMValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
