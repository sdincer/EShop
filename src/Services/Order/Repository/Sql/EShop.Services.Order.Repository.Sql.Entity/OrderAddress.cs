namespace EShop.Services.Order.Repository.Sql.Entity
{
    public class OrderAddress
    {
        public int OrderId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }

        public virtual Order Order { get; set; }
    }
}
