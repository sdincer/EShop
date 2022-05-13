namespace EShop.Services.Order.Repository.Mongo.Entity
{
    public class OrderProduct
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string BrandThumbnail { get; set; }
    }
}