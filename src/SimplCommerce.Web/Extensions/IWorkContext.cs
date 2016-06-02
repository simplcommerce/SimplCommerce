using SimplCommerce.Core.Domain.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Web.Extensions
{
    public interface IWorkContext
    {
        Task<User> GetCurrentUser();
    }
}
