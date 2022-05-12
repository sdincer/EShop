namespace EShop.Services.Product.Application.Abstraction.DataAccess.Models
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Brand { get; set; }
        public ICollection<string> Categories { get; set; }
    }
}
