using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class Vendor : EntityBase
    {
        public Vendor()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        [Required]
        [StringLength(450)]
        public string Slug { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset LatestUpdatedOn { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public IList<User> Users { get; set; } = new List<User>();
    }
}
