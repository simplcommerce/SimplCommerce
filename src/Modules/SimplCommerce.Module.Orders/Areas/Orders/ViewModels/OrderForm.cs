namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderForm
    {
        public long Id { get; set; }
        public long CustomerID { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaymentFeeAmount { get; set; }
    }
}
