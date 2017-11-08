using CqrsOrm.Core.Connection;

namespace CqrsOrm.Core.Query
{
    public interface IQuery<out T>
    {
        T Execute(IConnection connection);
    } 
}
