using CqrsOrm.ConsoleSample.Commands;
using CqrsOrm.ConsoleSample.Model;
using CqrsOrm.ConsoleSample.Queries;
using CqrsOrm.ConsoleSample.Service;
using CqrsOrm.Core.Context;
using CqrsOrm.Core.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsOrm.ConsoleSample.Service
{
    public class SupplierService : AbsSuppliersService
    {
        public SupplierService(IContext context) : base(context)
        {
        }

        public override void DeleteSuppliers()
        {
            _context.Execute(new DeleteSuppliers());
        }

        public override IEnumerable<Supplier> GetAllSuppliers()
        {

            return _context.Query(new GetAllSuppliers());
        }

        public override IEnumerable<Supplier> GetSuppliersByCountry(string country)
        {
            return _context.Query(new GetSuppliersByCommonName(country));
        }

        public override void SaveSupplier(Supplier supplier)
        {
            _context.Execute(new SaveSupplier(supplier));
        } 
    }
}
