using CqrsOrm.ConsoleSample.Model;
using CqrsOrm.Core.Command;
using CqrsOrm.Core.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsOrm.ConsoleSample.Commands
{ 
   public class SaveSupplier : ICommand
    {
        private readonly Supplier _supplier;

        public SaveSupplier(Supplier  supplier)
        {
            _supplier = supplier;
        }

        public void Execute(IConnection connection)
        {
            if (_supplier.SupplierId > 0)
            {
                connection.Execute("UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax, HomePage = @HomePage WHERE Id = @SupplierId", 
                    new { _supplier.SupplierId, _supplier.CompanyName, _supplier.ContactName, _supplier.ContactTitle, _supplier.Address, _supplier.City, _supplier.Region, _supplier.PostalCode, _supplier.Country, _supplier.Phone, _supplier.Fax, _supplier.HomePage });
                return;
            }

            connection.Execute("INSERT INTO Suppliers (CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage) VALUES (@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax,@HomePage)",
                new { _supplier.CompanyName, _supplier.ContactName, _supplier.ContactTitle, _supplier.Address, _supplier.City, _supplier.Region, _supplier.PostalCode, _supplier.Country, _supplier.Phone, _supplier.Fax, _supplier.HomePage});
        }
    }
}
