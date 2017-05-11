using System.Collections.Generic;

namespace CqrsOrm.Core.Connection
{
    public interface IConnection
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
    }
}
