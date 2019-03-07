using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class AddressFormVm : ValidatableObject
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public long StateOrProvinceId { get; set; }

        public long? DistrictId { get; set; }

        public string CountryId { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public IList<SelectListItem> StateOrProvinces { get; set; }

        public IList<SelectListItem> Districts { get; set; }

        public IList<SelectListItem> ShipableContries { get; set; }
    }
}
