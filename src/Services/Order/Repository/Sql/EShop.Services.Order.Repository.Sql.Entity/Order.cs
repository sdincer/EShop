namespace EShop.Services.Order.Repository.Sql.Entity
{
    public class Order
    {
        public Order()
        {
            Items = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }

        public virtual OrderAddress Address { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }
    }
}