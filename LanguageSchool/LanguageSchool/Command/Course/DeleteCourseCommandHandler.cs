using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Repositories;
using LanguageSchool.ValueObjects;


namespace LanguageSchool.Command.Course
{
    public sealed class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCourseCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Handle(DeleteCourseCommand command)
        {
            var course = _unitOfWork.CoursesRepository.GetById(new Id<Entities.Course>(command.Id));
            if (course == null)
            {
                return Result.Fail("Course does not exist.");
            }

            _unitOfWork.CoursesRepository.Remove(course);
            _unitOfWork.Commit();

            return Result.Ok();

        }
    }
}
