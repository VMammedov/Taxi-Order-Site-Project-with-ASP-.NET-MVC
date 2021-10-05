using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(x => x.ClientName).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(x => x.ClientSurName).NotEmpty().WithMessage("SurName can't be empty!");
            RuleFor(x => x.ClientProfession).NotEmpty().WithMessage("Profession can't be empty!");
            RuleFor(x => x.ClientNumber).NotEmpty().WithMessage("Number can't be empty!");
            RuleFor(x => x.Sex).NotEmpty().WithMessage("Gender can't be empty!");
            RuleFor(x => x.ClientMail).NotNull().NotEmpty().WithMessage("Mail can't be empty!");
            RuleFor(x => x.ClientName).NotNull().WithMessage("Name can't be null!");
            RuleFor(x => x.ClientSurName).NotNull().WithMessage("SurName can't be null!");
            RuleFor(x => x.ClientProfession).NotNull().WithMessage("Profession can't be null!");
            RuleFor(x => x.ClientNumber).NotNull().WithMessage("Number can't be null!");
            RuleFor(x => x.Sex).NotNull().WithMessage("Gender can't be null");
            RuleFor(x => x.ClientName).MinimumLength(2).WithMessage("Please include minimum 2 character for Name!");
            RuleFor(x => x.ClientSurName).MinimumLength(2).WithMessage("Please include minimum 2 character for SurName!");
            RuleFor(x => x.ClientName).MaximumLength(40).WithMessage("Please include maximum 40 character for Name!");
            RuleFor(x => x.ClientSurName).MaximumLength(50).WithMessage("Please include maximum 50 character for SurName!");
            RuleFor(x => x.ClientAbout).MaximumLength(350).WithMessage("Please include maximum 350 character for About!");
            RuleFor(x => x.ClientMail).EmailAddress();
            RuleFor(x => x.ClientMail).MaximumLength(60).WithMessage("Please include maximum 60 character for Email!");
            RuleFor(x => x.ClientImage).MaximumLength(300).WithMessage("Please change image name to less character image than this!");
            RuleFor(x => x.ClientNumber).MaximumLength(20).WithMessage("Number must be less than 20 character!");
            RuleFor(x => x.ClientNumber).MinimumLength(5).WithMessage("Number must be upper than 5 character!");
            
        }
    }
}
