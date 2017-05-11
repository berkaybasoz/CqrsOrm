
using CqrsOrm.Core.Command;
using CqrsOrm.Core.Connection;
using CqrsOrm.Core.Query; 

namespace CqrsOrm.Core.Context.Context
{
    public class ContextBase : IContext
    { 
        private IConnection _connection { get; set; }

        public ContextBase(IConnection connection)
        {
            _connection = connection;
        }

        public T Query<T>(IQuery<T> query)
        {
            var result = query.Execute(_connection);
            return result;
        }

        public void Execute(ICommand command)
        {
            command.Execute(_connection);
        }
    }
}
