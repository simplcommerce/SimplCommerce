using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.Contacts.ViewModels
{
    public class ContactForm
    {
        public string FullName { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string EmailAddress { get; set; }
        
        public string Address { get; set; }

        public string Content { get; set; }
        
        public string ContactArea { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
