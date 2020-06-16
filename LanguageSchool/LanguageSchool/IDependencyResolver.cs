using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool
{
    public interface IDependencyResolver
    {
        T ResolveOrDefault<T>() where T : class;
    }
}
