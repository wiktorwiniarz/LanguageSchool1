using System;
using System.Collections.Generic;
using System.Text;
using LanguageSchool.Command;
using LanguageSchool.Query;

namespace LanguageSchool
{
    public interface IMediator
    {
        Result Command<TCommand>(TCommand command) where TCommand : ICommand;

        TResponse Query<TResponse>(IQuery<TResponse> query);

        TResponse Query<TQuery, TResponse>(TQuery query) where TQuery : IQuery<TResponse>;
    }
}
