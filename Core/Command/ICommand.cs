using CqrsOrm.Core.Connection;

namespace CqrsOrm.Core.Command
{
    public interface ICommand
    {
        void Execute(IConnection connection);
    }
}
