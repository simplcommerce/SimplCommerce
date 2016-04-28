namespace Shopcuatoi.Core.Infrastructure.Resource
{
    public interface IResourceProvider
    {
        object GetResource(string name, string culture);
    }
}
