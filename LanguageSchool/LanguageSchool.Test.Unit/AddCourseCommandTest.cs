using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NSubstitute;
using LanguageSchool.Command.Course;
using LanguageSchool.Repositories;
using Xunit;

namespace LanguageSchool.Test.Unit
{
    public class AddCourseCommandTest
    {
        [Fact]
        public void AddCourse_WhenExist_ShouldFail()
        {
            using (var sut = new SystemUnderTest())
            {
                var command = new AddCourseCommand
                {
                    Name = "Kurs Angielskiego A1",
                    Year = 2019,
                    TrainingTime = 350

                };
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.CoursesRepository
                    .IsCourseExist(command.Name, command.Year)
                    .Returns(true);

                var handler = new AddCourseCommandHandler(unitOfWorkSubstitute);
                var result = handler.Handle(command);

                result.IsFailure.Should().Be(true);
            }
        }

        [Fact]
        public void AddCourse_WhenItIsPossible_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var command = new AddCourseCommand
                {
                    Name = "Kurs Angielskiego A1",
                    Year = 2019,
                    TrainingTime = 350

                };
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                var handler = new AddCourseCommandHandler(unitOfWorkSubstitute);
                var result = handler.Handle(command);

                result.IsSuccess.Should().Be(true);
            }
        }
    }
}
