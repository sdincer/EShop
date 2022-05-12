using EShop.Services.Customer.Application.Abstraction.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Customer.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Application.Abstraction.DataAccess.Models.Customer> GetCustomers()
        {
            return _dbContext.Customers.Select(m => new Application.Abstraction.DataAccess.Models.Customer
            {
                Email = m.Email,
                PhoneNumber = m.PhoneNumber,
                FirstName = m.FirstName,
                LastName = m.LastName
            }).ToList();
        }

        public Application.Abstraction.DataAccess.Models.Customer GetCustomerByEmail(string email)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == email);

            if(customer == null)
            {
                return null;
            }

            return new Application.Abstraction.DataAccess.Models.Customer
            {
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
        }

        public IEnumerable<Application.Abstraction.DataAccess.Models.Address> GetCustomerAddressesByEmail(string email)
        {
            var addresses = _dbContext.Addresses
                .Include(m => m.Customer)
                .Include(m => m.Neighbourhood)
                .ThenInclude(m => m.District)
                .ThenInclude(m => m.City)
                .Where(x => x.Customer.Email == email).ToList();

            if (addresses == null)
            {
                return Enumerable.Empty<Application.Abstraction.DataAccess.Models.Address>();
            }

            return addresses.Select(m => new Application.Abstraction.DataAccess.Models.Address
            {
                Id = m.Id,
                Name = m.Name,
                PostalCode = m.PostalCode,
                CityName = m.Neighbourhood.District.City.Name,
                DistrictName = m.Neighbourhood.District.Name,
                NeigbourhoodName = m.Neighbourhood.Name,
                AddressLine = m.AddressLine,
                IsSippingAddress = m.Type == Entity.AddressType.ShippingAddress
            }).ToList();
        }
    }
}
