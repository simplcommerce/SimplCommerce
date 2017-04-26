using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.Contact.Models
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

        public long CategoryId { get; set; }

        public ContactCategory Category { get; set; }
        
        public bool IsDeleted { get; set; }        

        public DateTimeOffset CreatedOn { get; set; }
        
        
    }
}
