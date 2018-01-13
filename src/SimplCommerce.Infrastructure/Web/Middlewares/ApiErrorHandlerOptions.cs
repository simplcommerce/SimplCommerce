using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Infrastructure.Web.Middlewares
{
    public class ApiErrorHandlerOptions
    {
        public List<string> HandledPaths { get; set; } = new List<string> { "/api" };
    }
}
