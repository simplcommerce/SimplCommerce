using System;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Contacts.Models
{
    public class Contact : EntityBase
    {
        public Contact()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        [StringLength(450)]
        public string FullName { get; set; }

        [StringLength(450)]
        public string PhoneNumber { get; set; }

        [StringLength(450)]
        public string EmailAddress { get; set; }

        [StringLength(450)]
        public string Address { get; set; }

        public string Content { get; set; }

        public long ContactAreaId { get; set; }

        public virtual ContactArea ContactArea { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
