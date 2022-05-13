namespace EShop.Services.Order.Application.Abstraction.DataAccess
{
    public interface IOrderRepository
    {
        int Create(Models.Order order);
    }
}
