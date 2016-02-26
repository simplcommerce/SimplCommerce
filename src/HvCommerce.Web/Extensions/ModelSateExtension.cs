using System.Collections;
using System.Linq;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace HvCommerce.Web.Extensions
{
    public static class ModelSateExtension
    {
        public static IDictionary ToDictionary(this ModelStateDictionary modelState)
        {
            return modelState.ToDictionary(
                k => k.Key,
                v => v.Value.Errors.Select(x => x.ErrorMessage).ToArray()
            );
        }
    }
}
