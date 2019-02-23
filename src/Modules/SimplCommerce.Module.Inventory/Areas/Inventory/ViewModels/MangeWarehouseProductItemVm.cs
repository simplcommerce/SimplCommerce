namespace SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels
{
    public class MangeWarehouseProductItemVm
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Sku { get; set; }

        public bool IsExistInWarehouse { get; set; }
    }
}
