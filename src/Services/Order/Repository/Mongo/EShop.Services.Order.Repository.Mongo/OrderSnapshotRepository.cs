using EShop.Services.Order.Application.Abstraction.DataAccess;
using EShop.Services.Order.Application.Abstraction.DataAccess.Models;
using EShop.Services.Order.Application.Abstraction.DataAccess.Models.Snapshot;
using MongoDB.Driver;

namespace EShop.Services.Order.Repository.Mongo
{
    internal class OrderSnapshotRepository : IOrderSnapshotRepository
    {
        private readonly IMongoCollection<Entity.OrderSnapshot> _orderSnapshotCollection;

        public OrderSnapshotRepository(string connectionString)
        {
            var dbClient = new MongoClient(connectionString);

            var database = dbClient.GetDatabase("eshop");
            _orderSnapshotCollection = database.GetCollection<Entity.OrderSnapshot>("order_snapshot");

            var dateIndex = Builders<Entity.OrderSnapshot>.IndexKeys.Ascending(m => m.CreatedAt);
            _orderSnapshotCollection.Indexes.CreateOne(new CreateIndexModel<Entity.OrderSnapshot>(dateIndex));
        }

        public void Create(OrderSnapshot snapshot)
        {
            _orderSnapshotCollection.InsertOne(new Entity.OrderSnapshot
            {
                OrderId = snapshot.Id,
                CreatedAt = snapshot.CreatedAt,
                TotalAmount = snapshot.TotalAmount,
                Customer = new Entity.OrderCustomer
                {
                    Email = snapshot.Customer.Email,
                    FirstName = snapshot.Customer.FirstName,
                    LastName = snapshot.Customer.LastName,
                    PhoneNumber = snapshot.Customer.PhoneNumber
                },
                ShippingAddress = new Entity.OrderAddress
                {
                    City = snapshot.ShippingAddress.City,
                    District = snapshot.ShippingAddress.District,
                    Neighbourhood = snapshot.ShippingAddress.Neighbourhood,
                    PostalCode = snapshot.ShippingAddress.PostalCode,
                    AddressLine = snapshot.ShippingAddress.AddressLine
                },
                BillingAddress = new Entity.OrderAddress
                {
                    City = snapshot.BillingAddress.City,
                    District = snapshot.BillingAddress.District,
                    Neighbourhood = snapshot.BillingAddress.Neighbourhood,
                    PostalCode = snapshot.BillingAddress.PostalCode,
                    AddressLine = snapshot.BillingAddress.AddressLine
                },
                Items = snapshot.Items.Select(x => new Entity.OrderItem
                {
                    Sku = x.Sku,
                    Quantity = x.Quantity,
                    Thumbnail = x.Thumbnail,
                    Price = x.Price,
                    UnitPrice = x.UnitPrice,
                    Product = new Entity.OrderProduct
                    {
                        Code = x.Product.Code,
                        Name = x.Product.Name,
                        Category = x.Product.Category,
                        Brand = x.Product.Brand,
                        BrandThumbnail = x.Product.BrandThumbnail
                    },
                    Properties = x.Properties.Select(y => new Entity.OrderItemProperty { Key = y.Key, Value = y.Value }).ToList()
                }).ToList()
            });
        }

        public IEnumerable<OrderSnapshot> GetOrders(DateTime? startDate, DateTime? endDate)
        {
            var filterBuilder = Builders<Entity.OrderSnapshot>.Filter;
            var filter = filterBuilder.Empty;

            if (startDate.HasValue)
            {
                filter = filterBuilder.Gte(m => m.CreatedAt, startDate.Value);
            }

            if (endDate.HasValue)
            {
                filter = filterBuilder.And(filter, filterBuilder.Lte(m => m.CreatedAt, endDate.Value));
            }

            return _orderSnapshotCollection.Find(filter).ToEnumerable().Select(m => new OrderSnapshot
            {
                Id = m.OrderId,
                CreatedAt = m.CreatedAt,
                TotalAmount = m.TotalAmount,
                Customer = new Customer
                {
                    Email = m.Customer.Email,
                    FirstName = m.Customer.FirstName,
                    LastName = m.Customer.LastName,
                    PhoneNumber = m.Customer.PhoneNumber
                },
                ShippingAddress = new OrderAddress
                {
                    City = m.ShippingAddress.City,
                    District = m.ShippingAddress.District,
                    Neighbourhood  = m.ShippingAddress.Neighbourhood,
                    PostalCode = m.ShippingAddress.PostalCode,
                    AddressLine = m.ShippingAddress.AddressLine
                },
                BillingAddress = new OrderAddress
                {
                    City = m.BillingAddress.City,
                    District = m.BillingAddress.District,
                    Neighbourhood = m.BillingAddress.Neighbourhood,
                    PostalCode = m.BillingAddress.PostalCode,
                    AddressLine = m.BillingAddress.AddressLine
                },
                Items = m.Items.Select(x => new Application.Abstraction.DataAccess.Models.Snapshot.OrderItem
                {
                    Sku = x.Sku,
                    Quantity = x.Quantity,
                    Thumbnail = x.Thumbnail,
                    Price = x.Price,
                    UnitPrice = x.UnitPrice,
                    Product = new OrderProduct
                    {
                        Code = x.Product.Code,
                        Name = x.Product.Name,
                        Category = x.Product.Category,
                        Brand = x.Product.Brand,
                        BrandThumbnail = x.Product.BrandThumbnail
                    },
                    Properties = x.Properties.Select(y => new KeyValuePair<string, string>(y.Key, y.Value)).ToList()
                }).ToList()
            }).ToList();    
        }
    }
}