namespace EShop.Services.Order.Repository.Mongo.Entity
{
    public class OrderAddress
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string AddressLine { get; set; }
    }
}