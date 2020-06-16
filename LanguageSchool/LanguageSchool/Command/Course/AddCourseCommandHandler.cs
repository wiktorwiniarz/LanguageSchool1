using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Repositories;

namespace LanguageSchool.Command.Course
{
    public sealed class AddCourseCommandHandler : ICommandHandler<AddCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(AddCourseCommand command)
        {
            var validationResult = new AddCourseCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var isExist = _unitOfWork.CoursesRepository.IsCourseExist(command.Name, command.Year);

            if (isExist)
            {
                return Result.Fail("This Course already exist");
            }

            var course = new Entities.Course(command.Name, command.Year, command.TrainingTime);
            _unitOfWork.CoursesRepository.Add(course);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}
