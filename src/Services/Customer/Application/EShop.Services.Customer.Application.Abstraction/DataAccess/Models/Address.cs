namespace EShop.Services.Customer.Application.Abstraction.DataAccess.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostalCode { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string NeigbourhoodName { get; set; }
        public string AddressLine { get; set; }
        public bool IsSippingAddress { get; set; }
    }
}
