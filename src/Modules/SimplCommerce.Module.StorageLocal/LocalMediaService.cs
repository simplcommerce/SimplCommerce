using System.IO;
using System.Threading.Tasks;
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

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var filePath = Path.Combine(GlobalConfiguration.WebRootPath, MediaRootFoler, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                await mediaBinaryStream.CopyToAsync(output);
            }
        }

        public Task DeleteMediaAsync(Media media)
        {
            return DeleteMediaAsync(media.FileName);
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var filePath = Path.Combine(GlobalConfiguration.WebRootPath, MediaRootFoler, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }
    }
}
