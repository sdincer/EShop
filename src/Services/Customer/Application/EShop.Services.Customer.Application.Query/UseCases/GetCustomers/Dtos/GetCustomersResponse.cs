namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomers.Dtos
{
    public class GetCustomersResponse
    {
        public IEnumerable<Abstraction.DataAccess.Models.Customer> Customers { get; set; }
    }
}
