namespace EShop.Services.Customer.Repository.Entity
{
    public class Neighbourhood
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        public virtual District District { get; set; }
    }
}
