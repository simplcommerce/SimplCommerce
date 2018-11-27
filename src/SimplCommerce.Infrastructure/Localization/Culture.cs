using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Infrastructure.Localization
{
    public class Culture : EntityBaseWithTypedId<string>
    {
        public Culture(string id)
        {
            Id = id;
        }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        public IList<Resource> Resources { get; set; }
    }
}