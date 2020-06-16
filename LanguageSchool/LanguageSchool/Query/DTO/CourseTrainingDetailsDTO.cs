using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Query.DTO
{
    public class CourseTrainingDetails
    {
        public CourseTrainingDetails(Course course, Entities.Training training)
        {
            CourseName = course.Name;
            CourseId = course.Id;
            TrainingId = training.Id;
            TrainingDate = training.Date;
        }

        public Id<Course> CourseId { get; }

        public Id<Entities.Training> TrainingId { get; }

        public string CourseName { get; }

        public DateTime TrainingDate { get; }
    }
}
