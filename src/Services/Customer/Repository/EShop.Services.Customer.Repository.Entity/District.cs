namespace EShop.Services.Customer.Repository.Entity
{
    public class District
    {
        public District()
        {
            Neighbourhoods = new HashSet<Neighbourhood>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Neighbourhood> Neighbourhoods { get; set; }
    }
}
