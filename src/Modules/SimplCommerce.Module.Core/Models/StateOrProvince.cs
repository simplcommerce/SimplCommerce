using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class StateOrProvince : EntityBase
    {
        public StateOrProvince()
        {

        }

        public StateOrProvince(long id)
        {
            Id = id;
        }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
