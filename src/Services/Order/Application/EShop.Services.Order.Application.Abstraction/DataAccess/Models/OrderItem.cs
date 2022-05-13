namespace EShop.Services.Order.Application.Abstraction.DataAccess.Models
{
    public class OrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
