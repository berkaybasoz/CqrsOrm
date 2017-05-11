using CqrsOrm.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CqrsOrm.Core.Context;
using CqrsOrm.ConsoleSample.Model;

namespace CqrsOrm.ConsoleSample.Service
{
    public abstract class AbsSuppliersService: ServiceBase
    {
        public AbsSuppliersService(IContext context) : base(context)
        {
        }

        public abstract IEnumerable<Suppliers> GetAllSuppliers();
        public abstract IEnumerable<Suppliers> GetSuppliersByCountry(string country);
        public abstract void SaveSuppliers(Suppliers suppliers);
    }
}
