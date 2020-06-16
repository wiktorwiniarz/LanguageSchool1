using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace LanguageSchool.Command.Bookings
{
    internal class BuyBookingCommandValidator : AbstractValidator<BuyBookingCommand>
    {
        public BuyBookingCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty();
            RuleFor(x => x.TrainingDate).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}
