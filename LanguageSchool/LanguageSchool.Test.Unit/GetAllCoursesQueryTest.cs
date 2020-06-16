using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NSubstitute;
using LanguageSchool.Entities;
using LanguageSchool.Query.Courses;
using LanguageSchool.Repositories;
using Xunit;


namespace LanguageSchool.Test.Unit
{
    public class GetAllCoursesQueryTest
    {
        [Fact]
        public void GetCourses_WhenItsExist_ReturnCorrectData()
        {
            using (var sut = new SystemUnderTest())
            {
                var course = sut.CreateCourse("Kurs Angielskiego A1", 2019, 350);
                var courses = new List<Course> { course };
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.CoursesRepository.GetAll().Returns(courses);

                var query = new GetAllCoursesQuery();
                var queryHandler = new GetAllCoursesQueryHandler(unitOfWorkSubstitute);
                var coursesQuery = queryHandler.Handle(query);

                coursesQuery[0].Name.Should().Be("Kurs Angielskiego A1");
            }
        }

        [Fact]
        public void GetCourses_WhenItsExist_ShouldSuccess()
        {
            using (var sut = new SystemUnderTest())
            {
                var course = sut.CreateCourse("Kurs Angielskiego A1", 2019, 350);
                var courses = new List<Course> { course };
                var unitOfWorkSubstitute = Substitute.For<IUnitOfWork>();

                unitOfWorkSubstitute.CoursesRepository.GetAll().Returns(courses);

                var query = new GetAllCoursesQuery();
                var queryHandler = new GetAllCoursesQueryHandler(unitOfWorkSubstitute);
                var coursesQuery = queryHandler.Handle(query);

                coursesQuery.Count.Should().Be(1);
            }
        }
    }
}
