namespace EShop.Services.Customer.Repository.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int NeighbourhoodId { get; set; }
        public AddressType Type { get; set; }
        public int PostalCode { get; set; }
        public string Name { get; set; }
        public string AddressLine { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Neighbourhood Neighbourhood { get; set; }
    }
}
