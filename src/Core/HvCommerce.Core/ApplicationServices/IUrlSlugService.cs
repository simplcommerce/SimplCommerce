using System.Collections.Generic;
using System.Threading.Tasks;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Core.ApplicationServices
{
    public interface IUrlSlugService
    {
        Task<List<UrlSlug>> Query();

        void Add(UrlSlug urlSlug);
    }
}