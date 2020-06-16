using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Command.Trainings
{
    public class RegisterTrainingCommand : ICommand
    {
        public Guid CourseId { get; set; }

        public DateTime TrainingDate { get; set; }
    }
}
