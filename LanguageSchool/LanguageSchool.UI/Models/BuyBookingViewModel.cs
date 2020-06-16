using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageSchool.UI.Models
{
    public class BuyBookingViewModel
    {
        public Guid CourseId { get; set; }

        public string CourseName { get; set; }

        public Guid TrainingId { get; set; }

        public DateTime TrainingDate { get; set; }

        public string Email { get; set; }

        public int Quantity { get; set; }
    }
}
