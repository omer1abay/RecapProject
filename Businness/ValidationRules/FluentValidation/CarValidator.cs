using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        //Kurallar constructor içine yazılır.
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2); //araba adı en az 2 karakter olmalı
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p=> p.DailyPrice).NotEmpty();
            RuleFor(p=> p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.CarId == 1);

            //custom kural
            RuleFor(p => p.Description).Must(StartWithsA).WithMessage("Ürünler A harfi ile başlamalıdır."); // kendi metodumuz..
        }

        private bool StartWithsA(string arg)
        {
            return arg.StartsWith('A');
        }

    }
}
