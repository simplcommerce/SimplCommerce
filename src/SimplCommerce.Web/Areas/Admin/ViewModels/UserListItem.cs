using System;

namespace SimplCommerce.Web.Areas.Admin.ViewModels
{
    public class UserListItem
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}