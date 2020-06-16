using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Repositories;

namespace LanguageSchool.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolBookingDbContext _context;

        public UnitOfWork(SchoolBookingDbContext context)
        {
            _context = context;
            CoursesRepository = new CoursesRepository(context);
        }


        public ICoursesRepository CoursesRepository { get; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
