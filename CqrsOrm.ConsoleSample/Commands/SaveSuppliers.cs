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
   public class SaveSuppliers : ICommand
    {
        private readonly Suppliers _suppliers;

        public SaveSuppliers(Suppliers  suppliers)
        {
            _suppliers = suppliers;
        }

        public void Execute(IConnection connection)
        {
            if (_suppliers.SupplierID > 0)
            {
                connection.Execute("UPDATE Animals SET CompanyName = @CompanyName, ContactName = @ContactName, ContactTitle = @ContactTitle, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Fax = @Fax, HomePage = @HomePage WHERE Id = @SupplierID", 
                    new { _suppliers.SupplierID, _suppliers.CompanyName, _suppliers.ContactName, _suppliers.ContactTitle, _suppliers.Address, _suppliers.City, _suppliers.Region, _suppliers.PostalCode, _suppliers.Country, _suppliers.Phone, _suppliers.Fax, _suppliers.HomePage });
                return;
            }

            connection.Execute("INSERT INTO Suppliers (CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax,HomePage) VALUES (@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country,@Phone,@Fax,@HomePage)",
                new { _suppliers.CompanyName, _suppliers.ContactName, _suppliers.ContactTitle, _suppliers.Address, _suppliers.City, _suppliers.Region, _suppliers.PostalCode, _suppliers.Country, _suppliers.Phone, _suppliers.Fax, _suppliers.HomePage});
        }
    }
}
