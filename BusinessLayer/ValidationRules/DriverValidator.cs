using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator()
        {
            RuleFor(x => x.DriverName).NotEmpty().WithMessage("You must fill Name Field!");
        }
    }
}
