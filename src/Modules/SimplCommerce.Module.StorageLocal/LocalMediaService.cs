using System.IO;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageLocal
{
    public class LocalMediaService : IMediaService
    {
        private const string MediaRootFoler = "user-content";
        private readonly IRepository<Media> _mediaRespository;

        public LocalMediaService(IRepository<Media> mediaRespository)
        {
            _mediaRespository = mediaRespository;
        }

        public string GetMediaUrl(Media media)
        {
            if (media != null)
            {
                return $"/{MediaRootFoler}/{media.FileName}";
            }

            return $"/{MediaRootFoler}/no-image.png";
        }

        public string GetMediaUrl(string fileName)
        {
            return $"/{MediaRootFoler}/{fileName}";
        }

        public string GetThumbnailUrl(Media media)
        {
            return GetMediaUrl(media);
        }

        public void SaveMedia(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var filePath = Path.Combine(GlobalConfiguration.WebRootPath, MediaRootFoler, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                mediaBinaryStream.CopyTo(output);
            }
        }

        public void DeleteMedia(Media media)
        {
            _mediaRespository.Remove(media);
            DeleteMedia(media.FileName);
        }

        public void DeleteMedia(string fileName)
        {
            var filePath = Path.Combine(GlobalConfiguration.WebRootPath, MediaRootFoler, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
