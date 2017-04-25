using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.Contact.Models
{
    public class ContactCategory : EntityBase
    {
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
