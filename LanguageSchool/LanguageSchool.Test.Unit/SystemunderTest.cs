using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.Test.Unit.Models;
namespace LanguageSchool.Test.Unit
{
    public class SystemUnderTest : IDisposable
    {
        public void Dispose()
        {
        }

        public Course CreateCourse(string name, int year, int trainingTime)
        {
            var course = new CourseProxy(name, year, trainingTime);
            course.Trainings.Add(new TrainingProxy(new DateTime(2019, 2, 28, 13, 0, 0), course.Id));
            course.Trainings.Add(new TrainingProxy(new DateTime(2019, 3, 1, 14, 0, 0), course.Id));
            course.Trainings.Add(new TrainingProxy(new DateTime(2019, 3, 1, 17, 0, 0), course.Id));

            return course;
        }
    }
}
