using EShop.Services.Order.Application.Abstraction.DataAccess;

namespace EShop.Services.Order.Repository.Sql
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Application.Abstraction.DataAccess.Models.Order order)
        {
            var newOrder = new Entity.Order()
            {
                CreatedAt = DateTime.Now,
                Status = Entity.OrderStatus.New,
                CustomerEmail = order.CustomerEmail,
                TotalAmount = order.Items.Sum(i => i.UnitPrice * i.Quantity),
                Items = order.Items.Select(i => new Entity.OrderItem()
                {
                    Amount = i.UnitPrice * i.Quantity,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Sku = i.Sku
                }).ToHashSet(),
                Address = new Entity.OrderAddress
                {
                    BillingAddressId = order.BillingAddressId,
                    ShippingAddressId = order.ShippingAddressId
                }
            };

            _dbContext.Orders.Add(newOrder);
            _dbContext.SaveChanges();

            return newOrder.Id;
        }
    }
}
