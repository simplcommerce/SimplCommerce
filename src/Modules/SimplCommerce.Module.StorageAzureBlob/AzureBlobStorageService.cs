using System.Diagnostics.Contracts;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageAzureBlob
{
    public class AzureBlobStorageService : IStorageService
    {
        private CloudBlobContainer _blobContainer;
        private string _publicEndpoint;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            var storageConnectionString = configuration["Azure:Blob:StorageConnectionString"];
            var containerName = configuration["Azure:Blob:ContainerName"];
            _publicEndpoint = configuration["Azure:Blob:PublicEndpoint"];

            Contract.Requires(string.IsNullOrWhiteSpace(storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(containerName));

            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = blobClient.GetContainerReference(containerName);

            if (string.IsNullOrWhiteSpace(_publicEndpoint))
            {
                _publicEndpoint = _blobContainer.Uri.AbsoluteUri;
            }

        }
        public async Task DeleteMediaAsync(string fileName)
        {
            var blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.DeleteIfExistsAsync();
        }

        public string GetMediaUrl(string fileName)
        {
            return $"{_publicEndpoint}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            await _blobContainer.CreateIfNotExistsAsync();
            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });

            var blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(mediaBinaryStream);
        }
    }
}
