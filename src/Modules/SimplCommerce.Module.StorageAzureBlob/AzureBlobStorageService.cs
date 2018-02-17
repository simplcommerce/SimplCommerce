using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SimplCommerce.Module.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.StorageAzureBlob
{
    public class AzureBlobStorageService : IStorageService
    {
        private CloudBlobContainer _blobContainer;

        public AzureBlobStorageService(IConfiguration configuration)
        {
            var storageConnectionString = configuration["Azure:Blob:StorageConnectionString"];
            var containerName = configuration["Azure:Blob:ContainerName"];

            Contract.Requires(string.IsNullOrWhiteSpace(storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(containerName));

            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            var blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = blobClient.GetContainerReference(containerName);

        }
        public async Task DeleteMediaAsync(string fileName)
        {
            var blockBlob = _blobContainer.GetBlockBlobReference(fileName);
            await blockBlob.DeleteIfExistsAsync();
        }

        public string GetMediaUrl(string fileName)
        {
            return $"{_blobContainer.Uri.AbsoluteUri}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });
            await _blobContainer.CreateIfNotExistsAsync();

            var blockBlob = _blobContainer.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(mediaBinaryStream);
        }

    }
}
