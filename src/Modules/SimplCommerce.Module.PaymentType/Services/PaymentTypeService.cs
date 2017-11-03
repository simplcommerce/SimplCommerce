using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Module.PaymentType.Models;
using SimplCommerce.Infrastructure.Data;

namespace SimplCommerce.Module.PaymentType.Services
{
    public class PaymentTypeService : IPaymentType
    {

        private readonly IRepository<Models.PaymentType> _paymentRepository;

        public PaymentTypeService(IRepository<Models.PaymentType> paymentReposetory)
        {
            _paymentRepository = paymentReposetory;
        }
        //public async Task<decimal>  CalculatePaymentType(int id, decimal total)
        //{
        //    decimal calculatedamount = 0;
        //    var query = _paymentRepository.Query().Where(x => x.Id == id).FirstOrDefault();

        //    if (Paymenttyp.Paypal == query.paymenttypep)
        //    {
        //        var mincharge = query.Min;
        //        var paypalpercent = query.Percent;
        //        var getpercent = CalculatePercent(paypalpercent);
        //        calculatedamount = getpercent * total;
        //        if (calculatedamount < mincharge)
        //        {
        //            calculatedamount = mincharge;
        //        }
        //        else
        //        {
        //            return calculatedamount;
        //        }
        //    }
        //    else if (Paymenttyp.Bank == query.paymenttypep)
        //    {
        //        return calculatedamount;
        //    }
        //    else if (Paymenttyp.Contrarembolso == query.paymenttypep)
        //    {
        //        var mincharge = query.Min;
        //        var paypalpercent = query.Percent;
        //        var getpercent = CalculatePercent(paypalpercent);
        //        calculatedamount = getpercent * cart.SubTotal;
        //        if (calculatedamount < mincharge)
        //        {
        //            calculatedamount = mincharge;
        //        }
        //        else
        //        {
        //            return calculatedamount; 
        //        }

        //    }
        //    return calculatedamount;
        //}

        public IEnumerable<Models.PaymentType> GetList()
        {
            return _paymentRepository.Query().ToList();
        }
        public Models.PaymentType Find(long id)
        {
            return _paymentRepository.Query().Where(x => x.Id == id).First();
        }

        public decimal Calculate(long paymentid , decimal total)
        {
            decimal calculatedamount = 0;
            var query = _paymentRepository.Query().Where(x => x.Id == paymentid).FirstOrDefault();
            
            if (Paymenttyp.Paypal == query.paymenttypep)
            {
                decimal mincharge = query.Min;
                var paypalpercent = query.Percent;
                var getpercent = CalculatePercent(paypalpercent);
                calculatedamount = getpercent * total;
                if (calculatedamount < mincharge)
                {
                    calculatedamount = mincharge;
                }
                else
                {
                    return calculatedamount;
                }
            }
            return calculatedamount;
        }
    
        private decimal CalculatePercent(decimal number)
            {
                return number / 100;
            }
    }
}
