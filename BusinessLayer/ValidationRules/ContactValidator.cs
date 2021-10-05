using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("Name field can't be empty or null!");
            RuleFor(x => x.Subject).NotNull().NotEmpty().WithMessage("Subject of message can't be empty or null!");
            RuleFor(x => x.Message).NotNull().NotEmpty().WithMessage("Message field can't be empty or null!");
            RuleFor(x => x.UserMail).NotNull().NotEmpty().WithMessage("Mail can't be empty or null!");
            RuleFor(x => x.UserMail).EmailAddress().WithMessage("Please include valid mail address!");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Please include minimum 3 character Name field!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Please include minimum 5 character for Subject field!");
            RuleFor(x => x.Message).MinimumLength(6).WithMessage("Please include minimum 6 character for Message!");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Please include maximum 50 character for Name field!");
            RuleFor(x => x.Subject).MaximumLength(60).WithMessage("Please include maximum 150 character for Subject field!");
            RuleFor(x => x.Message).MaximumLength(500).WithMessage("Please include maximum 500 character for Message!");
            RuleFor(x => x.UserMail).MaximumLength(60).WithMessage("Please include maximum 60 character for Email!");
        }
    }
}
