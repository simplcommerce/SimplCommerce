using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using System.Linq;

namespace SimplCommerce.Module.CustomerGroups.Services
{
    public class CustomerGroupService : ICustomerGroupService
    {
        private const long CustomerGroupEntityTypeId = 8;

        private readonly IRepository<CustomerGroup> _customergroupRepository;
        private readonly IEntityService _entityService;

        public CustomerGroupService(IRepository<CustomerGroup> customergroupRepository, IEntityService entityService)
        {
            _customergroupRepository = customergroupRepository;
            _entityService = entityService;
        }

        public void Create(CustomerGroup customergroup)
        {
            using (var transaction = _customergroupRepository.BeginTransaction())
            {
                _customergroupRepository.Add(customergroup);
                _customergroupRepository.SaveChange();

                _entityService.Add(customergroup.Name, customergroup.Name, customergroup.Id, CustomerGroupEntityTypeId);
                _customergroupRepository.SaveChange();

                transaction.Commit();
            }
        }

        public void Update(CustomerGroup customergroup)
        {
            _entityService.Update(customergroup.Name, customergroup.Name, customergroup.Id, CustomerGroupEntityTypeId);
            _customergroupRepository.SaveChange();
        }

        public void Delete(long id)
        {
            var customergroup = _customergroupRepository.Query().First(x => x.Id == id);
            Delete(customergroup);
        }

        public void Delete(CustomerGroup customergroup)
        {
            customergroup.IsDeleted = true;
            _entityService.Remove(customergroup.Id, CustomerGroupEntityTypeId);
            _customergroupRepository.SaveChange();
        }
    }
}
