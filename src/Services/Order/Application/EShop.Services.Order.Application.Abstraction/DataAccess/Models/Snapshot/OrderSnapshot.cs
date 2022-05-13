namespace EShop.Services.Order.Application.Abstraction.DataAccess.Models.Snapshot
{
    public class OrderSnapshot
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }
        public OrderAddress ShippingAddress { get; set; }
        public OrderAddress BillingAddress { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
