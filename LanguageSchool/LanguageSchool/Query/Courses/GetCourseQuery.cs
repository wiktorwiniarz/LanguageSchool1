using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.Query.DTO;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Query.Courses
{
    public class GetCourseQuery : IQuery<CourseDetailsDTO>
    {
        public GetCourseQuery(Guid courseId)
        {
           CourseId = new Id<Course>(courseId);
        }

        public Id<Course> CourseId { get; }
    }
}
