using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShop.Services.Order.Repository.Mongo.Entity
{
    public class OrderSnapshot
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public int OrderId { get; set; }
        public OrderCustomer Customer { get; set; }
        public OrderAddress ShippingAddress { get; set; }
        public OrderAddress BillingAddress { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}