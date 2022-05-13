namespace EShop.Services.Order.Repository.Mongo.Entity
{
    public class OrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public OrderProduct Product { get; set; }
        public IEnumerable<OrderItemProperty> Properties { get; set; }
    }
}