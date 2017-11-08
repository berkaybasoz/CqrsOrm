using CqrsOrm.Core.Command;
using CqrsOrm.Core.Query;
using System.Collections.Generic;

namespace CqrsOrm.Core.Context
{
    public interface IContext
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
    }
}
