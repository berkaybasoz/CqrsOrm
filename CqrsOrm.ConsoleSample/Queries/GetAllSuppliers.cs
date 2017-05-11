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
    class GetAllSuppliers : IQuery<IList<Suppliers>>
    {
        public IList<Suppliers> Execute(IConnection connection)
        {
            return connection.Query<Suppliers>("SELECT * FROM Suppliers order by SupplierID asc").ToList();
        }
    }
}
