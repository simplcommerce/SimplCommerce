using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentType.Services
{
    public interface IPaymentType
    {
        IEnumerable<SimplCommerce.Module.PaymentType.Models.PaymentType> GetList();
        decimal Calculate(long paymentid, decimal total);
        Models.PaymentType Find(long id);



    }
}
