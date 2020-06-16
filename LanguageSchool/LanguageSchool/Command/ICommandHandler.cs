using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageSchool.Command
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
