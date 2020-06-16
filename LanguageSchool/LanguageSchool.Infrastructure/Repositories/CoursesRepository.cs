using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LanguageSchool.Entities;
using LanguageSchool.Repositories;
using LanguageSchool.ValueObjects;

namespace LanguageSchool.Infrastructure.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly SchoolBookingDbContext _context;

        public CoursesRepository(SchoolBookingDbContext context)
        {
            _context = context;
        }

        public Course GetById(Id<Course> id)
        {
            return _context.Courses
                .Include(c => c.Trainings)
                .ThenInclude(c => c.Bookings)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public bool IsCourseExist(string name, int year)
        {
            return _context.Courses.Any(
                x => x.Name == name && x.Year == year);
        }

        public bool IsTrainingExist(DateTime trainingDate)
        {
            return _context.Trainings.Any(x => x.Date == trainingDate);
        }

        public List<Training> GetTrainingsByCourseId(Id<Course> courseId)
        {
            return _context.Trainings.Where(x => x.CourseId == courseId)
                .ToList();
        }

        public void Remove(Course course)
        {
            _context.Remove(course);
        }

        public void Update(Course course)
        {
            _context.Courses.Update(course);
        }

        public Course GetTrainingDetails(Id<Course> courseId)
        {
            return _context.Courses.Where(x => x.Id == courseId)
                .Include(t => t.Trainings)
                .FirstOrDefault();
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }
    }
}
