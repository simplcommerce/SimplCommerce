using System.ComponentModel.DataAnnotations;


namespace Shopcuatoi.Web.Areas.Admin.ViewModels
{
    public class ManufacturerForm
    {
        public ManufacturerForm()
        {
            IsPublished = true;
        }

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsPublished { get; set; }
    }
}
