using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Extensions
{
    public interface IWorkContext
    {
        string GetCurrentHostName();

        Task<User> GetCurrentUser();
    }
}
