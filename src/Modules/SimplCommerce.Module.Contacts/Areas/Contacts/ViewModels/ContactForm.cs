using System;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels
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
