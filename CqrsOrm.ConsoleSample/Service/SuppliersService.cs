using CqrsOrm.ConsoleSample.Commands;
using CqrsOrm.ConsoleSample.Model;
using CqrsOrm.ConsoleSample.Queries;
using CqrsOrm.ConsoleSample.Service;
using CqrsOrm.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsOrm.ConsoleSample.Service
{ 
   public class SuppliersService : AbsSuppliersService
    {
        public SuppliersService(IContext context) : base(context)
        {
        }

        public override IEnumerable<Suppliers> GetAllSuppliers()
        {
            return _context.Query(new GetAllSuppliers());
        } 
        public override IEnumerable<Suppliers> GetSuppliersByCountry(string country)
        {
            return _context.Query(new GetSuppliersByCommonName(country));
        }
          
        public override void SaveSuppliers(Suppliers suppliers)
        {
            _context.Execute(new SaveSuppliers(suppliers));
        }
    }
}
