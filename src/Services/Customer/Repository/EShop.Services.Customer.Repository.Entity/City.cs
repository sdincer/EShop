namespace EShop.Services.Customer.Repository.Entity
{
    public class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
