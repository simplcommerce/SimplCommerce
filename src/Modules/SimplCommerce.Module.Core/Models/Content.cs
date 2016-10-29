using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public abstract class Content : EntityBase
    {
        private bool isDeleted;

        protected Content()
        {
            CreatedOn = DateTimeOffset.Now;
            UpdatedOn = DateTimeOffset.Now;
        }

        public string Name { get; set; }

        public string SeoTitle { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public bool IsPublished { get; set; }

        public DateTimeOffset? PublishedOn { get; set; }

        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
                if (value)
                {
                    IsPublished = false;
                }
            }
        }

        public virtual User CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public virtual User UpdatedBy { get; set; }
    }
}
