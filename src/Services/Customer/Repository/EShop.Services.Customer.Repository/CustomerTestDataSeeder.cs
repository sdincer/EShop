namespace EShop.Services.Customer.Repository
{
    internal class CustomerTestDataSeeder
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerTestDataSeeder(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedTestData()
        {
            if (!_dbContext.Database.EnsureCreated())
            {
                return;
            }

            #region Brands

            var city1 = _dbContext.Cities.Add(new Entity.City
            {
                Code = 34,
                Name = "İstanbul",
                Districts = new HashSet<Entity.District>
                {
                    new Entity.District
                    { 
                        Name = "Kadıköy",
                        Neighbourhoods = new HashSet<Entity.Neighbourhood>
                        {
                            new Entity.Neighbourhood { Name = "Merdivenköy" }
                        }
                    }
                }                
            });
            var city2 = _dbContext.Cities.Add(new Entity.City
            {
                Code = 35,
                Name = "İzmir",
                Districts = new HashSet<Entity.District>
                {
                    new Entity.District
                    {
                        Name = "Urla",
                        Neighbourhoods = new HashSet<Entity.Neighbourhood>
                        {
                            new Entity.Neighbourhood { Name = "İskele" }
                        }
                    }
                }
            });

            var neighbourhoods1 = _dbContext.Neighbourhoods.Local.First(m => m.Name == "Merdivenköy");
            var neighbourhoods2 = _dbContext.Neighbourhoods.Local.First(m => m.Name == "İskele");

            #endregion

            #region Customers

            _dbContext.Customers.Add(new Entity.Customer
            {
                Email = "m.selim.dincer@gmail.com",
                PhoneNumber = "05077311389",
                FirstName = "Mustafa Selim",
                LastName = "Dinçer",
                Addresses = new HashSet<Entity.Address>
                {
                    new Entity.Address
                    {
                        Name = "Ev Adresi",
                        Neighbourhood = neighbourhoods1,
                        AddressLine = "İstanbul'da bir yer",
                        PostalCode = 34000,
                        Type = Entity.AddressType.ShippingAddress
                    },
                    new Entity.Address
                    {
                        Name = "İş Adresi",
                        Neighbourhood = neighbourhoods2,
                        AddressLine = "İzmir'de bir yer",
                        PostalCode = 35000,
                        Type = Entity.AddressType.BillingAddress
                    }
                }
            });

            #endregion

            _dbContext.SaveChanges();
        }
    }
}
