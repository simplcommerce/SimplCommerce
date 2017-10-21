using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Tax.ViewModels
{
    public class TaxClassForm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
