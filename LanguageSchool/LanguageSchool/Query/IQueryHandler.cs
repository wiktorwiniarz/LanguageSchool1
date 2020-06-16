using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Query
{
    public interface IQueryHandler<in TQuery, out TResult>
           where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
