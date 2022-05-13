using EShop.Services.Order.Application.Abstraction.DataAccess.Models;
using EShop.Services.Order.Application.Abstraction.DataAccess.Models.Snapshot;

namespace EShop.Services.Order.Application.Abstraction.DataAccess
{
    public interface IOrderSnapshotRepository
    {
        void Create(OrderSnapshot snapshot);
        IEnumerable<OrderSnapshot> GetOrders(DateTime? startDate, DateTime? endDate);
    }
}
