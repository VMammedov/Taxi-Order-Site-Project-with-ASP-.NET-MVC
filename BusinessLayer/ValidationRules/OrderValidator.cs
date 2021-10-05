using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.CarTypeID).NotNull().NotEmpty().WithMessage("Please select Car Type!");
            RuleFor(x => x.DropLocation).NotNull().NotEmpty().WithMessage("Please write drop location!");
            RuleFor(x => x.PickUpLocation).NotNull().NotEmpty().WithMessage("Please write pick up location!");
            RuleFor(x => x.PickUpTime).NotNull().NotEmpty().WithMessage("Please set pick up time!");
            RuleFor(x => x.PickUpLocation).MinimumLength(5).WithMessage("Please include minimum 5 character for Pick up location!");
            RuleFor(x => x.DropLocation).MinimumLength(5).WithMessage("Please include minimum 5 character for Drop location!");
            RuleFor(x => x.PickUpLocation).MaximumLength(150).WithMessage("Please include maximum 150 character for Pick up location!");
            RuleFor(x => x.DropLocation).MaximumLength(150).WithMessage("Please include maximum 150 character for Drop location!");
            RuleFor(x => x.OrderStatus).MaximumLength(1).WithMessage("Status maximum length is 1 character!");
        }
    }
}
