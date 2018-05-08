namespace SimplCommerce.Module.Core.Models
{
    public class CustomerGroupUser
    {
        public long UserId { get; set; }

        public User User { get; set; }

        public long CustomerGroupId { get; set; }

        public CustomerGroup CustomerGroup { get; set; }
    }
}
