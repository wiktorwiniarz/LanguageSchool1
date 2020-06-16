using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Command.Bookings
{
    public sealed class BuyBookingCommand : ICommand
    {
        public BuyBookingCommand(Id<Entities.Course> courseId, DateTime trainingDate, string email, int quantity)
        {
            TrainingDate = trainingDate;
            Email = email;
            Quantity = quantity;
            CourseId = courseId;
        }

        public Id<Entities.Course> CourseId { get; }

        public DateTime TrainingDate { get; }

        public string Email { get; }

        public int Quantity { get; }
    }
}
