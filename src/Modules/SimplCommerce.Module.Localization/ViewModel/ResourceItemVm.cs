namespace SimplCommerce.Module.Localization.ViewModel
{
    public class ResourceItemVm
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public long CultureId { get; set; }

        public bool IsTranslated { get; set; }
    }
}
