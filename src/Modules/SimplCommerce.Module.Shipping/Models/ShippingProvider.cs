using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Shipping.Models
{
    public class ShippingProvider : EntityBase
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public string ConfigureUrl { get; set; }

        public bool ToAllShippingEnabledCountries { get; set; }

        public string OnlyCountryIdsString { get; set; }

        public IList<long> OnlyCountryIds
        {
            get
            {
                if (string.IsNullOrWhiteSpace(OnlyCountryIdsString))
                {
                    return new List<long>();
                }

                return OnlyCountryIdsString.Split(',').Select(long.Parse).ToList();
            }
        }

        public bool ToAllShippingEnabledStatesOrProvinces { get; set; } 

        public string OnlyStateOrProvinceIdsString { get; set; }

        public IList<long> OnlyStateOrProvinceIds
        {
            get
            {
                if (string.IsNullOrWhiteSpace(OnlyStateOrProvinceIdsString))
                {
                    return new List<long>();
                }

                return OnlyStateOrProvinceIdsString.Split(',').Select(long.Parse).ToList();
            }
        }

        /// <summary>
        /// Additional setting for specific provider. Stored as json string.
        /// </summary>
        public string AdditionalSettings { get; set; }

        /// <summary>
        /// The type that 
        /// </summary>
        public string ShippingPriceServiceTypeName { get; set; }
    }
}
