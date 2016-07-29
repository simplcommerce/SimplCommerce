using System.IO;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Services
{
    public interface IMediaService
    {
        string GetMediaUrl(Media media);

        string GetMediaUrl(string fileName);

        string GetThumbnailUrl(Media media);

        void SaveMedia(Stream mediaBinaryStream, string fileName, string mimeType = null);

        void DeleteMedia(Media media);

        void DeleteMedia(string fileName);
    }
}
