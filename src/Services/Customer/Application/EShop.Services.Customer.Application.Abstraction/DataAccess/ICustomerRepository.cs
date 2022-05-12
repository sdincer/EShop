namespace EShop.Services.Customer.Application.Abstraction.DataAccess
{
    public interface ICustomerRepository
    {
        IEnumerable<Models.Customer> GetCustomers();
        Models.Customer GetCustomerByEmail(string email);
        IEnumerable<Models.Address> GetCustomerAddressesByEmail(string email);
    }
}
