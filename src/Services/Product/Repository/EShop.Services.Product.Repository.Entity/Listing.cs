namespace EShop.Services.Product.Repository.Entity
{
    public class Listing
    {
        public Listing()
        {
            Variants = new HashSet<ListingVariant>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Thumbnail { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<ListingVariant> Variants { get; set; }
    }
}
