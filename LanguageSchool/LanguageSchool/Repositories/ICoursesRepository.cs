using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Repositories
{
    public interface ICoursesRepository
    {
        Course GetById(Id<Course> id);

        IEnumerable<Course> GetAll();

        bool IsCourseExist(string name, int year);

        bool IsTrainingExist(DateTime trainingDate);

        void Add(Course course);

        void Update(Course course);

        Course GetTrainingDetails(Id<Course> courseId);

        List<Training> GetTrainingsByCourseId(Id<Course> courseId);

        void Remove(Course course);
    }
}
