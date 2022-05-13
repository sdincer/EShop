namespace EShop.Services.Order.Application.Abstraction.DataAccess.Models.Snapshot
{
    public class OrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public string Thumbnail { get; set; }
        public decimal Price { get; set; }
        public decimal UnitPrice { get; set; }
        public OrderProduct Product { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Properties { get; set; }
    }
}
