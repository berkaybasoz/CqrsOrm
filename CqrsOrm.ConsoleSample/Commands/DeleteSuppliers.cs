using CqrsOrm.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsOrm.Core.Connection;
using CqrsOrm.ConsoleSample.Model;

namespace CqrsOrm.ConsoleSample.Commands
{
    public class DeleteSuppliers : ICommand
    {
        public void Execute(IConnection connection)
        {
            connection.Execute("DELETE FROM Suppliers");
        }
    }
}
