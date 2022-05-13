namespace EShop.Services.Order.Repository.Mongo.Entity
{
    public class OrderCustomer
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}