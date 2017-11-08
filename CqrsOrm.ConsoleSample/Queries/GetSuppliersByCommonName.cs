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
    public class GetSuppliersByCommonName : IQuery<IList<Supplier>>
    {
        private readonly string _country;

        public GetSuppliersByCommonName (string country)
        {
            _country = country;
        }

        public IList<Supplier> Execute(IConnection connection)
        {
            return connection.Query<Supplier>("SELECT * FROM Suppliers WHERE Country = @Country", new { Country = _country }).ToList();
        }
    }
}
