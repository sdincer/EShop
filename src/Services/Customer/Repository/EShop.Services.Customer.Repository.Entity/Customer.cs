namespace EShop.Services.Customer.Repository.Entity
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
