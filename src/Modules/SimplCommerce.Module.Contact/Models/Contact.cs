using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.Contact.Models
{
    public class Contact : EntityBase
    {
        protected Contact()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string Content { get; set; }

        public long CategoryId { get; set; }

        public ContactCategory Category { get; set; }
        
        public bool IsDeleted { get; set; }

        public virtual User CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public virtual User UpdatedBy { get; set; }
    }
}
