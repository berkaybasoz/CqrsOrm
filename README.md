# CqrsOrm
Simple CQRS Pattern sample with Dapper.Net

	public class SampleDapperApp
	{
		private IContext context;
		private IConnection connection;
		private AbsSuppliersService service;
		private string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\App_Data\Suppliers.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
		public SampleDapperApp()
		{
			connection = new DapperConnection(connectionString);
			context = new ContextBase(connection);
			service = new SupplierService(context);
		}

		public void GetSuppliers()
		{
			IEnumerable<Supplier> suppliers = service.GetAllSuppliers();
			DisplaySuppliers(suppliers);
		}

		public void GetSuppliersByCountry()
		{
			IEnumerable<Supplier> suppliers = service.GetSuppliersByCountry(Country.Turkey.ToString());
			DisplaySuppliers(suppliers);
		}

		public void SaveSuppliers()
		{
			Supplier suppliers = new Supplier
			{
				CompanyName = "Deneme " + new Random().Next(1, 1000),
				Country = Country.Turkey,
				ContactName = "Berkay Başöz" + new Random().Next(1, 1000)
			};

			service.SaveSupplier(suppliers);

		}

		public void DeleteSuppliers()
		{
			service.DeleteSuppliers();
		}

		public void DisplaySuppliers(IEnumerable<Supplier> suppliers)
		{
			foreach (var supplier in suppliers)
			{
				Console.WriteLine($"Id {supplier.SupplierId} company {supplier.CompanyName} contact {supplier.ContactName}");
			}
		}

		public void DisplayLine()
		{
			Console.WriteLine($"-----------------------------------");
		}

		public void Wait()
		{
			Console.ReadLine();
		}
	}
  
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