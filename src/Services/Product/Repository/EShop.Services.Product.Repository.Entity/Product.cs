namespace EShop.Services.Product.Repository.Entity
{
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<Category>();
            Listings = new HashSet<Listing>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int UnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Unit Unit { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }
    }
}
