using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.Query.DTO;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Query.Training
{
    public class GetTrainingQuery : IQuery<CourseTrainingDetails>
    {
        public GetTrainingQuery(Guid courseId, Guid trainingId)
        {
            CourseId = new Id<Course>(courseId);
            TrainingId = new Id<Entities.Training>(trainingId);
        }

        public Id<Course> CourseId { get; }
        public Id<Entities.Training> TrainingId { get; }
    }
}
