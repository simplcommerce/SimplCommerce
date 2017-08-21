using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.CustomerGroups.ViewModels
{
    public class CustomerGroupForm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

    }
}
