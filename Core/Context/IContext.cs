using CqrsOrm.Core.Command;
using CqrsOrm.Core.Query;

namespace CqrsOrm.Core.Context 
{
    public interface IContext
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
    }
}
