using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace LanguageSchool.Command.Course
{
    internal class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
    {
        public EditCourseCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Year).InclusiveBetween(1900, 2040);
            RuleFor(x => x.TrainingTime).InclusiveBetween(300, 600);
        }

    }
}
