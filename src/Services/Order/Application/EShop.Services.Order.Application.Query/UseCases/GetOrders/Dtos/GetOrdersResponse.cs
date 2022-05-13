using EShop.Services.Order.Application.Abstraction.DataAccess.Models.Snapshot;

namespace EShop.Services.Order.Application.Query.UseCases.GetOrders.Dtos
{
    public class GetOrdersResponse
    {
        public IEnumerable<OrderSnapshot> Orders { get; set; }
    }
}
