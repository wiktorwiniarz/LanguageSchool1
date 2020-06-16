using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Query.DTO
{
    public class CourseDto
    {
        public CourseDto(string name, Id<Course> id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; }

        public Id<Course> Id { get; }
    }
}
