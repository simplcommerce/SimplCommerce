using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.CustomerGroups.Services
{
    public interface ICustomerGroupService
    {
        void Create(CustomerGroup customergroup);

        void Update(CustomerGroup customergroup);

        void Delete(long id);

        void Delete(CustomerGroup customergroup);
    }
}
