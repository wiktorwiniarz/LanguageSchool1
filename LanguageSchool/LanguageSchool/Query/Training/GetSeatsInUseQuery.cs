using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Query.Training
{
    public sealed class GetSeatsInUseQuery : IQuery<int>
    {
        public GetSeatsInUseQuery(Id<Course> courseId, DateTime trainingDate)
        {
            CourseId = courseId;
            TrainingDate = trainingDate;
        }

        public Id<Course> CourseId { get; }

        public DateTime TrainingDate { get; }
    }
}
