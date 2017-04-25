using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimplCommerce.Module.Contact.ViewModels
{
    public class ContactCategoryForm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
