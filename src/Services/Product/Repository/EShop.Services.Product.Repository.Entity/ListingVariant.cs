namespace EShop.Services.Product.Repository.Entity
{
    public class ListingVariant
    {
        public int VariantId { get; set; }
        public int ListingId { get; set; }
        public string Value { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
