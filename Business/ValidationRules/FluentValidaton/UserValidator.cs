﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidaton
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("Isminiz en az 2 karakter olmalidir");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyisiminiz en az 2 karakter olmalidir");
            RuleFor(u => u.Password).MinimumLength(5).WithMessage("Sifreniz minimum 5 karakter olmalidir");
        }
    }
}
