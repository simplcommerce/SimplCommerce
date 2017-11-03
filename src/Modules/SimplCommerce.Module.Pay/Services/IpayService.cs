
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Pay.Services
{
    public interface IpayService
    {
        void MakePayment(long orderid);
    }
}
