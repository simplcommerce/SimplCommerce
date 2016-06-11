using System.IO;
using SimplCommerce.Core.Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SimplCommerce.Core.ApplicationServices
{
    public class AzureMediaService : IMediaService
    {
        private string _storagePath;
        private IConfigurationRoot _conf;
        private IHostingEnvironment _env;
        private IRepository<Media> _mediaRepository;
        private CloudStorageAccount _storageAccount;
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;


        public AzureMediaService(IHostingEnvironment env, IConfigurationRoot conf, IRepository<Media> mediaRespository)
        {
            _env = env;
            _conf = conf;
            _mediaRepository = mediaRespository;
            _storagePath = _conf["Storage:AzureStorage:StoragePath"];

            _storageAccount = _env.IsDevelopment() ? CloudStorageAccount.DevelopmentStorageAccount :
                CloudStorageAccount.Parse(_conf["Storage: AzureStorage:StorageConnectionString"]);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _container = _blobClient.GetContainerReference("images");

            InitializeStorage();
        }

        public void DeleteMedia(Media media)
        {
            _mediaRepository.Remove(media);
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(media.FileName);
            blockBlob.DeleteAsync().Wait();
        }

        public string GetMediaUrl(string fileName)
        {
            return $"{_storagePath}{fileName}";
        }

        public string GetMediaUrl(Media media)
        {
            if (media != null)
            {
                return $"{_storagePath}{media.FileName}";
            }

            return $"{_storagePath}default.png";
        }

        public string GetThumbnailUrl(Media media)
        {
            return GetMediaUrl(media);
        }

        public void SaveMedia(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            CloudBlockBlob blockBlob = _container.GetBlockBlobReference(fileName);
            blockBlob.Properties.ContentType = mimeType;
            blockBlob.UploadFromStreamAsync(mediaBinaryStream).Wait();
        }

        private void InitializeStorage()
        {
            if (_container.CreateIfNotExistsAsync().Result)
            {
                _container.SetPermissionsAsync(
                new BlobContainerPermissions
                {
                    PublicAccess =
                        BlobContainerPublicAccessType.Blob
                }).Wait();
            }
        }
    }
}
