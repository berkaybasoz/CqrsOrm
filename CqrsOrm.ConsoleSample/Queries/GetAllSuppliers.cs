using CqrsOrm.ConsoleSample.Model;
using CqrsOrm.Core.Connection;
using CqrsOrm.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsOrm.ConsoleSample.Queries
{
    public class GetAllSuppliers : IQuery<IList<Supplier>>
    {
        public IList<Supplier> Execute(IConnection connection)
        {
            return connection.Query<Supplier>("SELECT * FROM Suppliers order by SupplierID asc").ToList();
        }
    }
}
