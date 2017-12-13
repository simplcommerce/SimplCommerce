using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.StorageAzureBlobStorage
{
    public class AzureBlobMediaService : IMediaService
    {
        private string _storageConnectionString;
        private string _storageContainer;
        private bool _retryOnFailure;
        private string _publicEndpoint;

        public AzureBlobMediaService(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetValue("Azure:Blob:StorageConnectionString", string.Empty);
            _storageContainer = configuration.GetValue("Azure:Blob:StorageContainer", string.Empty);
            _retryOnFailure = configuration.GetValue("Azure:Blob:RetryOnFailure", false);
            _publicEndpoint = configuration["Azure:Blob:PublicEndpoint"];

            Contract.Requires(string.IsNullOrWhiteSpace(_storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(_storageContainer));
        }

        public Task DeleteMediaAsync(Media media)
        {
            return DeleteMediaAsync(media.FileName);
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            var blob = await CreateBlockBlob(fileName);
            await blob.DeleteIfExistsAsync();
        }

        public string GetMediaUrl(Media media)
        {
            return GetMediaUrl(media.FileName);
        }

        public string GetMediaUrl(string fileName)
        {
            return string.Concat(_publicEndpoint, fileName);
        }

        public string GetThumbnailUrl(Media media)
        {
            return string.Concat(_publicEndpoint, media.FileName);
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            if (mediaBinaryStream == null)
                throw new ArgumentNullException(nameof(mediaBinaryStream));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentNullException(nameof(fileName));

            var blob = await CreateBlockBlob(fileName);

            if (!string.IsNullOrEmpty(mimeType))
                blob.Properties.ContentType = mimeType;

            await blob.UploadFromStreamAsync(mediaBinaryStream, mediaBinaryStream.Length);
        }

        private IRetryPolicy GetRetryPolicy()
        {
            if (_retryOnFailure)
                return new LinearRetry();

            return new NoRetry();
        }

        private async Task<CloudBlockBlob> CreateBlockBlob(string blobName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_storageConnectionString);

            CloudBlobClient serviceClient = storageAccount.CreateCloudBlobClient();

            var container = serviceClient.GetContainerReference(_storageContainer);

            BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = GetRetryPolicy() };
            await container.CreateIfNotExistsAsync(requestOptions, null);
            return container.GetBlockBlobReference(blobName);
        }
    }
}