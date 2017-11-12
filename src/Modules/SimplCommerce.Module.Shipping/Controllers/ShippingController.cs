using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Shipping.Services;
using SimplCommerce.Module.Shipping.ViewModels;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimplCommerce.Module.Shipping.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;
        private readonly IRepository<ShippingProvider> _shippingProviderRepo;
        private readonly IRepository<UserAddress> _shippinguseraddressReposetory;
        private readonly IRepository<Address> _shippingaddressReposetory;
        private readonly IRepository<Country> _shippingconuntryReposetory;

        public ShippingController(
            IShippingService shippingService, 
            IRepository<ShippingProvider> shippingProviderRepository,
            IRepository<UserAddress> shippinguseraddressRepository,
            IRepository<Country> shippingcountryRepository,
            IRepository<Address> shippingaddressReposetory
         )
        {
            _shippingService = shippingService;
            _shippingProviderRepo = shippingProviderRepository;
            _shippinguseraddressReposetory = shippinguseraddressRepository;
            _shippingconuntryReposetory = shippingcountryRepository;
            _shippingaddressReposetory = shippingaddressReposetory;
        }

        [HttpPost]
        public async Task<IActionResult> GetShippingRate(ShippingAddressVmAjax model)
        {

            //shippingaddressvmajax is for testing i am getting everything null but in consolelog have json object
            //var request = new GetShippingRateRequest
            //{
            //    OrderAmount = model.OrderAmount,
            //    ShippingAddress = new Address
            //    {
            //        CountryId = model.ShippingAddress.CountryId,
            //        StateOrProvinceId = model.ShippingAddress.StateOrProvinceId,
            //        AddressLine1 = model.ShippingAddress.AddressLine1
            //    }
            //};
            //var applicableShippingRates = await _shippingService.GetApplicableShippingRates(request);

            //return Ok(applicableShippingRates);
            return null;
        }
        [HttpGet]
        public async Task<IEnumerable<object>> GetShippingProviders()
        {
            //we have to add decs fiel in provider if some one want to explane some extra explanation  !!!

            IEnumerable<object> shippingproviderlist = _shippingProviderRepo.Query().Where(x=>x.IsEnabled == true).Select(x => new { Id = x.Id, Name = x.Name });

            return shippingproviderlist;
        }
        [HttpGet]
        public JsonResult GetConutryByName(string name)
        {
            var country = _shippingconuntryReposetory.Query().Where(x => x.Name == name).Select(x=> new { id = x.Id});
            return Json(country);
        }
        [HttpGet]
        public JsonResult GetShippingAddress( long id)
        {
            var useraddress =  _shippinguseraddressReposetory.Query().Where(x => x.Id == id).FirstOrDefault();
            var address = _shippingaddressReposetory.Query().Where(x => x.Id == useraddress.AddressId).Select(x => new { id = x.Id, countryid = x.CountryId, provinceid = x.StateOrProvinceId, line1 = x.AddressLine1 });

            return Json(address);
        }
    }
}
