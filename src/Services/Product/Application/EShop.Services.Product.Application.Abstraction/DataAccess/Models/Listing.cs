namespace EShop.Services.Product.Application.Abstraction.DataAccess.Models
{
    public class Listing
    {
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public string ProductUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public string Thumbnail { get; set; }
        public bool InStock { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }
}
