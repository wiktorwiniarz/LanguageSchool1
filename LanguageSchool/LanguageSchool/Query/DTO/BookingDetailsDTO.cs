using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Entities;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Query.DTO
{
   public  class BookingDetailsDTO
    {
        public BookingDetailsDTO(string email, int peopleCount, Id<Booking> id, DateTime purchesDate)
        {
            Email = email;
            PeopleCount = peopleCount;
            Id = id;
            PurchesDate = purchesDate;
        }

        public string Email { get; }

        public Id<Booking> Id { get; }

        public int PeopleCount { get; }

        public DateTime PurchesDate { get; }
    }
}
