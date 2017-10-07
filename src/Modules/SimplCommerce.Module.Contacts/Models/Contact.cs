using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Contacts.Models
{
    public class Contact : EntityBase
    {
        public Contact()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string Content { get; set; }

        public long ContactAreaId { get; set; }

        public virtual ContactArea ContactArea { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
