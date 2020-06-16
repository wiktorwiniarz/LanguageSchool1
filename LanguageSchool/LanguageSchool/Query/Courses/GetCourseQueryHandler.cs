using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageSchool.Query.DTO;
using LanguageSchool.Repositories;

namespace LanguageSchool.Query.Courses
{
    public class GetCourseQueryHandler : IQueryHandler<GetCourseQuery, CourseDetailsDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCourseQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CourseDetailsDTO Handle(GetCourseQuery query)
        {
            var course = _unitOfWork.CoursesRepository.GetById(query.CourseId);
            if (course == null)
            {
                throw new NullReferenceException("Given course does not exist.");
            }

            var trainings = new List<TrainingDTO>();

            if (course.Trainings != null)
            {
                trainings = course.Trainings
                    .Select(item => new TrainingDTO(item.Id.Value, item.Date))
                    .ToList();
            }

            return new CourseDetailsDTO(course.Id.Value, course.Name, course.Year, course.TrainingTime, trainings);
        }
    }
}
