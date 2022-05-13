namespace EShop.Services.Order.Application.Abstraction.DataAccess.Models
{
    public class Order
    {
        public string CustomerEmail { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
