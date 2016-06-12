using System.IO;
using SimplCommerce.Core.Domain.Models;

namespace SimplCommerce.Core.ApplicationServices
{
    public interface IMediaService
    {
        string GetMediaUrl(Media media);

        string GetMediaUrl(string fileName);

        string GetThumbnailUrl(Media media);

        void SaveMedia(Stream mediaBinaryStream, string fileName, string mimeType = null);

        void DeleteMedia(Media media);
    }
}