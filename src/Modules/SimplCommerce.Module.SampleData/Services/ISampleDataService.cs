using System.Threading.Tasks;
using SimplCommerce.Module.SampleData.ViewModels;

namespace SimplCommerce.Module.SampleData.Services
{
    public interface ISampleDataService
    {
        Task ResetToSampleData(SampleDataOption model);
    }
}
