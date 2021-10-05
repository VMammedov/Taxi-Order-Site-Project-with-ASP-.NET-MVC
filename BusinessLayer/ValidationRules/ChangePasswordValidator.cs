using EntityLayer.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.oldpassword).NotNull().NotEmpty().WithMessage("Please enter Old Password!");
            RuleFor(x => x.password1).NotNull().NotEmpty().WithMessage("Please enter new password to first Password field!");
            RuleFor(x => x.password2).NotNull().NotEmpty().WithMessage("Please enter new password to second Password field!");
            RuleFor(x => x.oldpassword).MinimumLength(5).WithMessage("Password must be upper than 5 character!");
            RuleFor(x => x.password1).MinimumLength(5).WithMessage("Password must be upper than 5 character!");
            RuleFor(x => x.password2).MinimumLength(5).WithMessage("Password must be upper than 5 character!");
            RuleFor(x => x.oldpassword).MaximumLength(35).WithMessage("Password must be less than 35 character!");
            RuleFor(x => x.password1).MaximumLength(35).WithMessage("Password must be less than 35 character!");
            RuleFor(x => x.password2).MaximumLength(35).WithMessage("Password must be less than 35 character!");
            RuleFor(x => x.password2).Equal(x => x.password1).WithMessage("Please make sure the passwords are the same!");
        }
    }
}
