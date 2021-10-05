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
            RuleFor(x => x.DriverName).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(x => x.DriverSurName).NotEmpty().WithMessage("SurName can't be empty!");
            RuleFor(x => x.DriverProfession).NotEmpty().WithMessage("Profession can't be empty!");
            RuleFor(x => x.DriverNumber).NotEmpty().WithMessage("Number can't be empty!");
            RuleFor(x => x.Sex).NotEmpty().WithMessage("Gender can't be empty");
            RuleFor(x => x.DriverMail).NotNull().NotEmpty().WithMessage("Mail can't be empty!");
            RuleFor(x => x.DriverName).NotNull().WithMessage("Name can't be null!");
            RuleFor(x => x.DriverSurName).NotNull().WithMessage("SurName can't be null!");
            RuleFor(x => x.DriverProfession).NotNull().WithMessage("Profession can't be null!");
            RuleFor(x => x.DriverNumber).NotNull().WithMessage("Number can't be null!");
            RuleFor(x => x.Sex).NotNull().WithMessage("Gender can't be null");
            RuleFor(x => x.DriverName).MinimumLength(2).WithMessage("Please include minimum 2 character for Name!");
            RuleFor(x => x.DriverSurName).MinimumLength(2).WithMessage("Please include minimum 2 character for SurName!");
            RuleFor(x => x.DriverName).MaximumLength(40).WithMessage("Please include maximum 40 character for Name!");
            RuleFor(x => x.DriverSurName).MaximumLength(50).WithMessage("Please include maximum 50 character for SurName!");
            RuleFor(x => x.DriverAbout).MaximumLength(350).WithMessage("Please include maximum 350 character for About!");
            RuleFor(x => x.DriverMail).EmailAddress();
            RuleFor(x => x.DriverMail).MaximumLength(60).WithMessage("Please include maximum 60 character for Email!");
            RuleFor(x => x.DriverImage).MaximumLength(300).WithMessage("Please change image name to less character image than this!");
            RuleFor(x => x.DriverNumber).MaximumLength(20).WithMessage("Number must be less than 20 character!");
            RuleFor(x => x.DriverNumber).MinimumLength(5).WithMessage("Number must be upper than 5 character!");
        }
    }
}
