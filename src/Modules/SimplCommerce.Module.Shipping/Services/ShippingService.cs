using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Services
{
    public class ShippingService : IShippingService
    {
        private IRepository<ShippingMethod> _shippingmethodRepository;

        public ShippingService(IRepository<ShippingMethod> shippingmethodRepository)
        {
            _shippingmethodRepository = shippingmethodRepository;
        }
        public decimal Calculate(long shippingid , decimal total)
        {
            decimal calculatedamount = 0;
            var query = _shippingmethodRepository.Query().Where(x => x.Id == shippingid).FirstOrDefault();

            if (query != null)
            {
                decimal mincharge = 2;
                
                if (calculatedamount < mincharge)
                {
                    calculatedamount = mincharge;
                }

                if (query.Name == "Correos")
                {
                    calculatedamount = query.ShippingPrice;
                }
                if (query.Name == "Nasic")
                {
                    calculatedamount = query.ShippingPrice;
                }
                else
                {
                    return calculatedamount;
                }
            }
            return calculatedamount;
        }
        public ShippingMethod Find(long id)
        {
            return _shippingmethodRepository.Query().Where(x => x.Id == id).First();
        }
    }
}
