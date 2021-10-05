using EntityLayer.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class DriverDtoValidator : AbstractValidator<DriverLoginDto>
    {
        public DriverDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("SurName can't be empty!");
            RuleFor(x => x.Profession).NotEmpty().WithMessage("Profession can't be empty!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Number can't be empty!");
            RuleFor(x => x.Sex).NotEmpty().WithMessage("Gender can't be empty");
            RuleFor(x => x.Name).NotNull().WithMessage("Name can't be null!");
            RuleFor(x => x.SurName).NotNull().WithMessage("SurName can't be null!");
            RuleFor(x => x.Profession).NotNull().WithMessage("Profession can't be null!");
            RuleFor(x => x.Phone).NotNull().WithMessage("Number can't be null!");
            RuleFor(x => x.Sex).NotNull().WithMessage("Gender can't be null");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Please include minimum 2 character for Name!");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Please include minimum 2 character for SurName!");
            RuleFor(x => x.Name).MaximumLength(40).WithMessage("Please include maximum 40 character for Name!");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Please include maximum 50 character for SurName!");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Email).MaximumLength(60).WithMessage("Please include maximum 60 character for Email!");
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage("Number must be less than 20 character!");
            RuleFor(x => x.Phone).MinimumLength(6).WithMessage("Number must be upper than 6 character!");
            RuleFor(x => x.Password1).NotNull().NotEmpty().WithMessage("Please enter Password!");
            RuleFor(x => x.Password2).NotNull().NotEmpty().WithMessage("Please enter Password!");
            RuleFor(x => x.Password1).MinimumLength(5).WithMessage("Password must be upper than 5 character!");
            RuleFor(x => x.Password2).MinimumLength(5).WithMessage("Password must be upper than 5 character!");
            RuleFor(x => x.Password1).MaximumLength(35).WithMessage("Password must be less than 35 character!");
            RuleFor(x => x.Password2).MaximumLength(35).WithMessage("Password must be less than 35 character!");
            RuleFor(x => x.Password2).Equal(x => x.Password1).WithMessage("Please make sure the passwords are the same!");
        }
    }
}
