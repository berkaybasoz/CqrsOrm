
using CqrsOrm.ConsoleSample.Model;
using CqrsOrm.ConsoleSample.Service;
using CqrsOrm.Core.Connection;
using CqrsOrm.Core.Context;
using CqrsOrm.Core.Context.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsOrm.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleDapperConsoleApp app = new SampleDapperConsoleApp();
            app.GetSuppliers();
            app.DisplayLine();
            app.GetSuppliersByCountry();
            app.DisplayLine();
            app.SaveSuppliers();
            app.DisplayLine();
            app.GetSuppliers();
            app.DisplayLine();
            app.Stop();
        }

        public class SampleDapperConsoleApp
        {
            private IContext _context;
            private IConnection _connection;
            private SuppliersService _service;
            public SampleDapperConsoleApp()
            {
                string connectionString = @"Server=.\SQLEXPRESS;Database=NORTHWND;Trusted_Connection=True;";
                _connection = new DapperConnection(connectionString);
                _context = new ContextBase(_connection);
                _service = new SuppliersService(_context);
            }

            public void GetSuppliers()
            {
                IEnumerable<Suppliers> suppliers = _service.GetAllSuppliers();
                DisplaySuppliers(suppliers);
            }

            public void GetSuppliersByCountry()
            {
                IEnumerable<Suppliers> suppliers = _service.GetSuppliersByCountry("USA");
                DisplaySuppliers(suppliers);
            }

            public void SaveSuppliers()
            {
                Suppliers suppliers = new Suppliers
                {
                    CompanyName = "Deneme " + new Random().Next(1, 1000),
                    Country = "USA"
                };

                _service.SaveSuppliers(suppliers);

            }

            private void DisplaySuppliers(IEnumerable<Suppliers> suppliers)
            {
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"ID {supplier.SupplierID} company {supplier.CompanyName} contact {supplier.ContactName}");
                }
            }

            public void DisplayLine()
            {
                Console.WriteLine($"-----------------------------------"); 
            }

            public void Stop()
            {
                Console.ReadLine();
            }
        }
    }
}
