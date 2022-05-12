namespace EShop.Services.Product.Repository.Entity
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            ChildCategories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
