using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICoursesRepository CoursesRepository { get; }
        void Commit();
    }
}
