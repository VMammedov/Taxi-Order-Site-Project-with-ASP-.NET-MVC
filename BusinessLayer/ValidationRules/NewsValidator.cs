using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class NewsValidator : AbstractValidator<News>
    {
        public NewsValidator()
        {
            RuleFor(x => x.NewsHeading).NotNull().NotEmpty().WithMessage("Heading of News can't be empty or null!");
            RuleFor(x => x.NewsValue).NotNull().NotEmpty().WithMessage("Subject of news can't be empty or null!");
            RuleFor(x => x.NewsImage).NotNull().NotEmpty().WithMessage("Image of news can't be empty or null!");
            RuleFor(x => x.NewsHeading).MinimumLength(3).WithMessage("Please include minimum 3 character News Heading!");
            RuleFor(x => x.NewsValue).MinimumLength(10).WithMessage("Please include minimum 10 character for News Content!");
            RuleFor(x => x.NewsImage).MinimumLength(3).WithMessage("Please check Image Name for it's length must be greater than 3 character!");
            RuleFor(x => x.NewsHeading).MaximumLength(50).WithMessage("Please include maximum 50 character for News Heading!");
            RuleFor(x => x.NewsValue).MaximumLength(1000).WithMessage("Please include maximum 1000 character for News Message!");
            RuleFor(x => x.NewsImage).MaximumLength(300).WithMessage("Please check Image Name for it's length must be less than 300 character!");
        }
    }
}
