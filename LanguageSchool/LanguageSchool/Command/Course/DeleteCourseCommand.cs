using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Command.Course
{
    public sealed class DeleteCourseCommand : ICommand
    {
        public DeleteCourseCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
