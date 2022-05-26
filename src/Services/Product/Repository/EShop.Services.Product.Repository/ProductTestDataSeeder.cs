namespace EShop.Services.Product.Repository
{
    public class ProductTestDataSeeder
    {
        private readonly ProductDbContext _dbContext;

        public ProductTestDataSeeder(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedTestData()
        {
            if (!_dbContext.Database.EnsureCreated())
            {
                return;
            }

            #region Brands

            var brand1 = _dbContext.Brands.Add(new Entity.Brand
            {
                Name = "Adidas",
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/2/20/Adidas_Logo.svg"
            });
            var brand2 = _dbContext.Brands.Add(new Entity.Brand
            {
                Name = "Beko",
                Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/New_Beko_logo.svg/220px-New_Beko_logo.svg.png"
            });

            #endregion

            #region Categories


            _dbContext.Categories.AddRange(new List<Entity.Category> {
                new Entity.Category {
                    Name = "Kadın",
                    ChildCategories = new List<Entity.Category>
                    {
                        new Entity.Category {
                            Name = "Spor Giyim",
                            ChildCategories = new List<Entity.Category>
                            {
                                new Entity.Category{ Name = "T-Shirt" }
                            }
                        },
                    }
                },
                new Entity.Category {
                    Name = "Erkek",
                    ChildCategories = new List<Entity.Category>
                    {
                        new Entity.Category {
                            Name = "Ayakkabı",
                            ChildCategories = new List<Entity.Category>
                            {
                                new Entity.Category{ Name = "Spor Ayakkabı" }
                            }
                        },
                    }
                },
                new Entity.Category {
                    Name = "Elektronik",
                    ChildCategories = new List<Entity.Category>
                    {
                        new Entity.Category {
                            Name = "Ev Elektroniği",
                            ChildCategories = new List<Entity.Category>
                            {
                                new Entity.Category{
                                    Name = "Çamaşır Makinası",
                                    ChildCategories= new List<Entity.Category>
                                    {
                                        new Entity.Category
                                        {
                                            Name = "Kurutmalı Çamaşır Makinası"
                                        }
                                    }
                                }
                            }
                        },
                    }
                 }
            });

            var category1 = _dbContext.Categories.Local.First(m => m.Name == "T-Shirt");
            var category2 = _dbContext.Categories.Local.First(m => m.Name == "Spor Ayakkabı");
            var category3 = _dbContext.Categories.Local.First(m => m.Name == "Kurutmalı Çamaşır Makinası");

            #endregion

            #region Units

            var unit1 = _dbContext.Units.Add(new Entity.Unit { Name = "Adet", ShortName = "Adet" });

            #endregion

            #region Variants

            var variant1 = _dbContext.Variants.Add(new Entity.Variant { Name = "Renk" });
            var variant2 = _dbContext.Variants.Add(new Entity.Variant { Name = "Beden" });
            var variant3 = _dbContext.Variants.Add(new Entity.Variant { Name = "Yıkama Kapasitesi" });
            var variant4 = _dbContext.Variants.Add(new Entity.Variant { Name = "Kurutma Kapasitesi" });

            #endregion

            #region Products

            var product1 = _dbContext.Products.Add(new Entity.Product
            {
                Name = "Adidas Sportsware Teamsport T-Shirt",
                Unit = unit1.Entity,
                Brand = brand1.Entity,
                Categories = new HashSet<Entity.Category> { category1 },
                Code = "H67027"
            });
            var product2 = _dbContext.Products.Add(new Entity.Product
            {
                Name = "OZWEEGO Ayakkabı",
                Unit = unit1.Entity,
                Brand = brand1.Entity,
                Categories = new HashSet<Entity.Category> { category2 },
                Code = "GX3324"
            });
            var product3 = _dbContext.Products.Add(new Entity.Product
            {
                Name = "BK 851 YKI Beko Kurutmalı Çamaşır Makinası",
                Unit = unit1.Entity,
                Brand = brand2.Entity,
                Categories = new HashSet<Entity.Category> { category3 },
                Code = "BK851YKI"
            });

            #endregion

            #region Listings

            _dbContext.Listings.AddRange(new List<Entity.Listing>
            {
                new Entity.Listing
                {
                    Product = product1.Entity,
                    Sku = "H6702701",
                    Stock = 12,
                    Thumbnail = string.Empty,
                    UnitPrice = 999,
                    Variants = new HashSet<Entity.ListingVariant>
                    {
                        new Entity.ListingVariant{ Variant = variant1.Entity, Value = "Beyaz" },
                        new Entity.ListingVariant{ Variant = variant2.Entity, Value = "M" },
                    }
                },
                new Entity.Listing
                {
                    Product = product1.Entity,
                    Sku = "H6702702",
                    Stock = 9,
                    Thumbnail = string.Empty,
                    UnitPrice = 1022,
                    Variants = new HashSet<Entity.ListingVariant>
                    {
                        new Entity.ListingVariant{ Variant = variant1.Entity, Value = "Siyah" },
                        new Entity.ListingVariant{ Variant = variant2.Entity, Value = "S" },
                    }
                },
                new Entity.Listing
                {
                    Product = product1.Entity,
                    Sku = "H6702703",
                    Stock = 9,
                    Thumbnail = string.Empty,
                    UnitPrice = 1022
                },
                new Entity.Listing
                {
                    Product = product2.Entity,
                    Sku = "GX332401",
                    Stock = 39,
                    Thumbnail = string.Empty,
                    UnitPrice = 750,
                    Variants = new HashSet<Entity.ListingVariant>
                    {
                        new Entity.ListingVariant{ Variant = variant1.Entity, Value = "Siyah" },
                        new Entity.ListingVariant{ Variant = variant2.Entity, Value = "44" },
                    }
                },
                new Entity.Listing
                {
                    Product = product3.Entity,
                    Sku = "BK851YKI01",
                    Stock = 7,
                    Thumbnail = string.Empty,
                    UnitPrice = 13500,
                    Variants = new HashSet<Entity.ListingVariant>
                    {
                        new Entity.ListingVariant{ Variant = variant1.Entity, Value = "Metalik Gri" },
                        new Entity.ListingVariant{ Variant = variant3.Entity, Value = "11.5 kg" },
                        new Entity.ListingVariant{ Variant = variant4.Entity, Value = "7 kg" },
                    }
                },
                new Entity.Listing
                {
                    Product = product3.Entity,
                    Sku = "BK851YKI02",
                    Stock = 3,
                    Thumbnail = string.Empty,
                    UnitPrice = 9300,
                    Variants = new HashSet<Entity.ListingVariant>
                    {
                        new Entity.ListingVariant{ Variant = variant1.Entity, Value = "Metalik Gri" },
                        new Entity.ListingVariant{ Variant = variant3.Entity, Value = "9 kg" },
                        new Entity.ListingVariant{ Variant = variant4.Entity, Value = "6 kg" },
                    }
                }
            });

            #endregion

            _dbContext.SaveChanges();
        }
    }
}
