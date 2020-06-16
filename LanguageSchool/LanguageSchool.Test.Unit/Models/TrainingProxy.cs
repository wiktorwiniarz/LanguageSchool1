using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Test.Unit.Models
{
    public class TrainingProxy : Training
    {
        public TrainingProxy(DateTime date, Id<Course> courseId) : base(date, courseId)
        {
            Bookings = new List<Booking>();
        }
    }
}
