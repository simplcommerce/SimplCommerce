namespace ResourceBuilder.Resource
{
    public interface IResourceProvider
    {
        object GetResource(string name, string culture);
    }
}
