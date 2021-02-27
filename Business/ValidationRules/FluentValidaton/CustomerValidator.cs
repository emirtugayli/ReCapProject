using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidaton
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(cu => cu.UserId).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(4).WithMessage("Sirket ismi minimum 4 karakter olmalidir");
        }
    }
}
