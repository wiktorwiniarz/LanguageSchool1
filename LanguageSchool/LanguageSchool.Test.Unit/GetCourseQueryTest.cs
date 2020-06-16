using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using LanguageSchool.Entities;
using LanguageSchool.Query.Courses;
using LanguageSchool.Repositories;
using Xunit;

namespace LanguageSchool.Test.Unit
{
    public class GetCourseQueryTest
    {
        [Fact]
        public void GetCourse_WhenItsExist_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var course = sut.CreateCourse("Kurs Angielskiego A1", 2019, 350);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.CoursesRepository.GetById(course.Id).Returns(course);

                var query = new GetCourseQuery(course.Id.Value);
                var queryHandler = new GetCourseQueryHandler(unitOfWorkSubstitute);
                var coursesQuery = queryHandler.Handle(query);

                coursesQuery.Name.Should().Be("Kurs Angielskiego A1");
            }
        }

        [Fact]
        public void GetCourse_WhenNoTraining_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var course = new Course("Kurs Angielskiego A1", 2019, 350);
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.CoursesRepository.GetById(course.Id)
                    .Returns(course);

                var query = new GetCourseQuery(course.Id.Value);
                var queryHandler = new GetCourseQueryHandler(unitOfWorkSubstitute);
                var coursesQuery = queryHandler.Handle(query);

                coursesQuery.Trainings.Count.Should().Be(0);
            }
        }
    }
}
