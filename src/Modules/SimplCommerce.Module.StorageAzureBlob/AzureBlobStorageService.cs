using System.Diagnostics.Contracts;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageAzureBlob
{
    public class AzureBlobStorageService : IStorageService
    {
        private BlobContainerClient _blobContainer;
        private string _publicEndpoint;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            var storageConnectionString = configuration["Azure:Blob:StorageConnectionString"];
            var containerName = configuration["Azure:Blob:ContainerName"];
            _publicEndpoint = configuration["Azure:Blob:PublicEndpoint"];

            Contract.Requires(string.IsNullOrWhiteSpace(storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(containerName));


            var blobClient = new BlobServiceClient(storageConnectionString);
            _blobContainer = blobClient.GetBlobContainerClient(containerName);

            if (string.IsNullOrWhiteSpace(_publicEndpoint))
            {
                _publicEndpoint = _blobContainer.Uri.AbsoluteUri;
            }

        }
        public async Task DeleteMediaAsync(string fileName)
        {
            var blockBlob = _blobContainer.GetBlobClient(fileName);
            await blockBlob.DeleteIfExistsAsync();
        }

        public string GetMediaUrl(string fileName)
        {
            return $"{_publicEndpoint}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            await _blobContainer.CreateIfNotExistsAsync();
            await _blobContainer.SetAccessPolicyAsync(accessType: PublicAccessType.BlobContainer);

            var blockBlob = _blobContainer.GetBlobClient(fileName);

            var blobHttpHeader = mimeType != null ? new BlobHttpHeaders { ContentType = mimeType } : null;

            if (await blockBlob.ExistsAsync())
            {
                if (blobHttpHeader != null)
                {
                    await blockBlob.SetHttpHeadersAsync(blobHttpHeader);
                }

                await blockBlob.UploadAsync(mediaBinaryStream, overwrite: true);
            }
            else
            {
                await blockBlob.UploadAsync(mediaBinaryStream, blobHttpHeader);
            }
        }
    }
}
