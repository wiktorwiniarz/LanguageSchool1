using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Entities
{
    public class Booking
    {
        protected Booking()
        {
        }

        public Booking(string email, int peopleCount)
        {
            Email = email;
            PeopleCount = peopleCount;
            PurchesDate = DateTime.UtcNow;
            Id = new Id<Booking>(Guid.NewGuid());
        }

        public string Email { get; protected set; }

        public Id<Booking> Id { get; protected set; }

        public int PeopleCount { get; protected set; }

        public DateTime PurchesDate { get; protected set; }

        public Id<Training> TrainingId { get; protected set; }
    }
}
