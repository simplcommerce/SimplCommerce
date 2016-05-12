using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Web.Areas.Admin.ViewModels.Resources
{
    public class ResourceForm
    {
        public long Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Culture { get; set; }
    }
}
