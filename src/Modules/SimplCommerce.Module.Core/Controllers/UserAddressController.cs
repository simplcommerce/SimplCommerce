using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize]
    public class UserAddressController : Controller
    {
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IRepository<Country> _countryRepository;
        private readonly IRepository<StateOrProvince> _stateOrProvinceRepository;
        private readonly IRepository<District> _districtRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IWorkContext _workContext;

        public UserAddressController(IRepository<UserAddress> userAddressRepository, IRepository<Country> countryRepository, IRepository<StateOrProvince> stateOrProvinceRepository,
            IRepository<District> districtRepository, IRepository<User> userRepository, IWorkContext workContext)
        {
            _userAddressRepository = userAddressRepository;
            _countryRepository = countryRepository;
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
            _userRepository = userRepository;
            _workContext = workContext;
        }

        [Route("user/address")]
        public async Task<IActionResult> List()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var model = _userAddressRepository
                .Query()
                .Where(x => x.AddressType == AddressType.Shipping && x.UserId == currentUser.Id)
                .Select(x => new UserAddressListItem
                {
                    AddressId = x.AddressId,
                    UserAddressId = x.Id,
                    ContactName = x.Address.ContactName,
                    Phone = x.Address.Phone,
                    AddressLine1 = x.Address.AddressLine1,
                    AddressLine2 = x.Address.AddressLine1,
                    DistrictName = x.Address.District.Name,
                    StateOrProvinceName = x.Address.StateOrProvince.Name,
                    CountryName = x.Address.Country.Name,
                    DisplayCity = x.Address.Country.IsCityEnabled,
                    DisplayPostalCode = x.Address.Country.IsPostalCodeEnabled,
                    DisplayDistrict = x.Address.Country.IsDistrictEnabled
                }).ToList();

            foreach (var item in model)
            {
                item.IsDefaultShippingAddress = item.UserAddressId == currentUser.DefaultShippingAddressId;
            }

            return View(model);
        }

        [Route("user/address/create")]
        public IActionResult Create()
        {
            var model = new UserAddressFormViewModel();

            PopulateAddressFormData(model);

            return View(model);
        }

        [Route("user/address/create")]
        [HttpPost]
        public async Task<IActionResult> Create(UserAddressFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _workContext.GetCurrentUser();

                var address = new Address
                {
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    ContactName = model.ContactName,
                    CountryId = model.CountryId,
                    StateOrProvinceId = model.StateOrProvinceId,
                    DistrictId = model.DistrictId,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    Phone = model.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Shipping,
                    UserId = currentUser.Id
                };

                _userAddressRepository.Add(userAddress);
                _userAddressRepository.SaveChanges();
                return RedirectToAction("List");
            }

            PopulateAddressFormData(model);
            return View(model);
        }

        [Route("user/address/edit/{id}")]
        public async Task<IActionResult> Edit(long id)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var userAddress = _userAddressRepository.Query()
                .Include(x => x.Address)
                .FirstOrDefault(x => x.Id == id && x.UserId == currentUser.Id);

            if (userAddress == null)
            {
                return NotFound();
            }

            var model = new UserAddressFormViewModel
            {
                Id = userAddress.Id,
                ContactName = userAddress.Address.ContactName,
                Phone = userAddress.Address.Phone,
                AddressLine1 = userAddress.Address.AddressLine1,
                AddressLine2 = userAddress.Address.AddressLine2,
                CountryId = userAddress.Address.CountryId,
                DistrictId = userAddress.Address.DistrictId,
                StateOrProvinceId = userAddress.Address.StateOrProvinceId,
                City = userAddress.Address.City,
                PostalCode = userAddress.Address.PostalCode
            };

            PopulateAddressFormData(model);

            return View(model);
        }

        [Route("user/address/edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Edit(long id, UserAddressFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _workContext.GetCurrentUser();

                var userAddress = _userAddressRepository.Query()
                    .Include(x => x.Address)
                    .FirstOrDefault(x => x.Id == id && x.UserId == currentUser.Id);

                if (userAddress == null)
                {
                    return NotFound();
                }

                userAddress.Address.AddressLine1 = model.AddressLine1;
                userAddress.Address.AddressLine2 = model.AddressLine2;
                userAddress.Address.ContactName = model.ContactName;
                userAddress.Address.CountryId = model.CountryId;
                userAddress.Address.StateOrProvinceId = model.StateOrProvinceId;
                userAddress.Address.DistrictId = model.DistrictId;
                userAddress.Address.City = model.City;
                userAddress.Address.PostalCode = model.PostalCode;
                userAddress.Address.Phone = model.Phone;

                _userAddressRepository.SaveChanges();
                return RedirectToAction("List");
            }

            PopulateAddressFormData(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetAsDefault(long id)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var userAddress = _userAddressRepository.Query()
                .FirstOrDefault(x => x.Id == id && x.UserId == currentUser.Id);

            if (userAddress == null)
            {
                return NotFound();
            }

            currentUser.DefaultShippingAddressId = userAddress.Id;
            _userRepository.SaveChanges();

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var userAddress = _userAddressRepository.Query()
                .FirstOrDefault(x => x.Id == id && x.UserId == currentUser.Id);

            if (userAddress == null)
            {
                return NotFound();
            }

            if (currentUser.DefaultShippingAddressId == userAddress.Id)
            {
                currentUser.DefaultShippingAddressId = null;
            }

            _userAddressRepository.Remove(userAddress);
            _userAddressRepository.SaveChanges();

            return RedirectToAction("List");
        }

        private void PopulateAddressFormData(UserAddressFormViewModel model)
        {
            var shippableCountries = _countryRepository.Query()
                .Where(x => x.IsShippingEnabled)
                .OrderBy(x => x.Name);

            model.Countries = shippableCountries
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            var onlyShipableCountryId = model.CountryId > 0 ? model.CountryId : long.Parse(model.Countries.First().Value);

            var selectedCountry = shippableCountries.FirstOrDefault(c => c.Id == model.CountryId);

            if (selectedCountry != null)
            {
                model.DisplayCity = selectedCountry.IsCityEnabled;
                model.DisplayDistrict = selectedCountry.IsDistrictEnabled;
                model.DisplayPostalCode = selectedCountry.IsPostalCodeEnabled;
            }


            model.StateOrProvinces = _stateOrProvinceRepository
                .Query()
                .Where(x => x.CountryId == onlyShipableCountryId)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            if (model.StateOrProvinceId > 0)
            {
                model.Districts = _districtRepository
                    .Query()
                    .Where(x => x.StateOrProvinceId == model.StateOrProvinceId)
                    .OrderBy(x => x.Name)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }).ToList();
            }
        }
    }
}
