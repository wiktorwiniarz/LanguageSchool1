using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NSubstitute;
using LanguageSchool.Query.Training;
using LanguageSchool.Repositories;
using Xunit;

namespace LanguageSchool.Test.Unit
{
    public class GetTraningQueryTest
    {
        [Fact]
        public void GetTraining_WhenItsExist_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var course = sut.CreateCourse("Kurs Angielskiego A1", 2019, 350);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.CoursesRepository.GetTrainingDetails(course.Id)
                    .Returns(course);

                var query = new GetTrainingQuery(course.Id.Value, course.Trainings.First().Id.Value);
                var queryHandler = new GetTrainingQueryHandler(unitOfWorkSubstitute);
                var trainingQuery = queryHandler.Handle(query);

                trainingQuery.CourseName.Should().Be("Kurs Angielskiego A1");
            }
        }
    }
}
