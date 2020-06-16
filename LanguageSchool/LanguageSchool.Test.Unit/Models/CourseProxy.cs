using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;

namespace LanguageSchool.Test.Unit.Models
{
    public class CourseProxy : Course
    {
        public CourseProxy(string name, int year, int trainingTime) : base(name, year, trainingTime)
        {
            Trainings = new List<Training>();
        }
    }
}
