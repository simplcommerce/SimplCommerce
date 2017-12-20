namespace SimplCommerce.Module.PaymentPaypalExpress.ViewModels
{
    public class ExperienceProfile
    {
        public string id { get; set; }

        public string name { get; set; }

        public InputFields input_fields { get; set; }

    }

    public class InputFields
    {
        public int no_shipping { get; set; }
    }
}
