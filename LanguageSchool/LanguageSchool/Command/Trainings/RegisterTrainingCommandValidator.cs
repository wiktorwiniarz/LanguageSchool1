using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace LanguageSchool.Command.Trainings
{
    internal class RegisterTrainingCommandValidator : AbstractValidator<RegisterTrainingCommand>
    {
        public RegisterTrainingCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEmpty();
            RuleFor(x => x.TrainingDate).NotEmpty().GreaterThan(DateTime.UtcNow);
        }
    }
}
