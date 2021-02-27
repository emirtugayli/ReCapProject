using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidaton
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Gecmis gunler icin araba kiralayamazsiniz");
            RuleFor(r => r.CarId).NotEmpty().WithMessage("Araba ID'si olmadan kiralayamazsiniz");
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate).WithMessage("Kiralama tarihi teslim tarihindan once olmalidir.");
        }
    }
}
