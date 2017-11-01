using System.IO;
using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public interface IMediaService
    {
        string GetMediaUrl(Media media);

        string GetMediaUrl(string fileName);

        string GetThumbnailUrl(Media media);

        Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null);

        Task DeleteMediaAsync(Media media);

        Task DeleteMediaAsync(string fileName);
    }
}
