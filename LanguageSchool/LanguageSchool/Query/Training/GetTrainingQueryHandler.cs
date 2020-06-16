using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageSchool.Query.DTO;
using LanguageSchool.Repositories;

namespace LanguageSchool.Query.Training
{
    public class GetTrainingQueryHandler : IQueryHandler<GetTrainingQuery, CourseTrainingDetails>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTrainingQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CourseTrainingDetails Handle(GetTrainingQuery query)
        {
            var course = _unitOfWork.CoursesRepository.GetTrainingDetails(query.CourseId);
            if (course == null)
            {
                throw new NullReferenceException("Given course does not exist.");
            }

            var training = course.Trainings.SingleOrDefault(x => x.Id == query.TrainingId);
            if (training == null)
            {
                throw new NullReferenceException("Given training does not exist.");
            }

            return new CourseTrainingDetails(course, training);
        }
    }
}