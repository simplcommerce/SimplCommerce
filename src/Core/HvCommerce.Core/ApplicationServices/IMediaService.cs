using System.IO;
using HvCommerce.Core.Domain.Models;

namespace HvCommerce.Core.ApplicationServices
{
    public interface IMediaService
    {
        string GetMediaUrl(Media media);

        string GetThumbnailUrl(Media media);

        void SaveMedia(Stream mediaBinaryStream, string fileName);
    }
}