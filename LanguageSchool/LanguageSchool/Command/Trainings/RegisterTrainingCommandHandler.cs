using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.Repositories;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Command.Trainings
{
    internal class RegisterTrainingCommandHandler : ICommandHandler<RegisterTrainingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterTrainingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(RegisterTrainingCommand command)
        {
            var validationResult = new RegisterTrainingCommandValidator().Validate(command);
            if (validationResult.IsValid == false)
            {
                return Result.Fail(validationResult);
            }

            var courseId = new Id<Entities.Course>(command.CourseId);

            var isTrainingExist = _unitOfWork.CoursesRepository.IsTrainingExist(command.TrainingDate);
            if (isTrainingExist)
            {
                return Result.Fail("This training already exist");
            }

            var course = _unitOfWork.CoursesRepository.GetById(courseId);
            if (course == null)
            {
                return Result.Fail("This course does not exist");
            }

            var training = new Training(command.TrainingDate, courseId);

            course.Trainings.Add(training);
            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}