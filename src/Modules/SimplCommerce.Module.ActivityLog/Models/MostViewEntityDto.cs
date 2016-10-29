using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.ActivityLog.Models
{
    public class MostViewEntityDto
    {
        public long EntityId { get; set; }

        public long EntityTypeId { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public int ViewedCount { get; set; }
    }
}
