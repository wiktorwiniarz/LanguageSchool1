using LanguageSchool.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Command.Course
{
    public sealed class EditCourseCommandHandler : ICommandHandler<EditCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(EditCourseCommand command)
        {
            var validationResult = new EditCourseCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var course = _unitOfWork.CoursesRepository.GetById(new Id<Entities.Course>(command.Id));
            if (course == null)
            {
                return Result.Fail("Course does not exist.");
            }

            course.SetName(command.Name);
           course.SetYear(command.Year);
           course.SetTrainingTime(command.TrainingTime);

            _unitOfWork.CoursesRepository.Update(course);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}
