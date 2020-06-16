using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Command.Course
{
    public sealed class EditCourseCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int TrainingTime { get; set; }
    }
}
