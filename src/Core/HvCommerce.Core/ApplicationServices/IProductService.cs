using System.Collections.Generic;
using System.Threading.Tasks;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Core.ApplicationServices
{
    public interface IProductService
    {
        Task<bool> CheckExistBySeoTitle(string seoTitle);
    }
}