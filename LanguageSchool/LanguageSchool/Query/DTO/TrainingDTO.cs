using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Query.DTO
{
    public class TrainingDTO
    {
        public TrainingDTO(Guid id, DateTime date)
        {
            Date = date;
            Id = id;
        }

        public Guid Id { get; }

        public DateTime? Date { get; }
    }
}
