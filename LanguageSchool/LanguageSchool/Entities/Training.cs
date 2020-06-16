using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Entities
{
    public class Training
    {
        protected Training()
        {
        }

        public Training(DateTime date, Id<Course> courseId)
        {
            Id = new Id<Training>(Guid.NewGuid());
            Date = date;
            CourseId = courseId;
        }

        public DateTime Date { get; protected set; }

        public Id<Training> Id { get; protected set; }

        public Id<Course> CourseId { get; protected set; }

        public virtual ICollection<Booking> Bookings { get; protected set; }

        public List<Booking> GetBookingByEmail(string email)
        {
            return Bookings.Where(x => x.Email == email)
                .OrderBy(x => x.PurchesDate)
                .ToList();
        }

        public List<Booking> GetAllTrainingBooking()
        {
            return Bookings == null ? new List<Booking>()
                :   Bookings.ToList();
        }

        public void Add(Booking booking)
        {
            Bookings.Add(booking);
        }
    }
}
