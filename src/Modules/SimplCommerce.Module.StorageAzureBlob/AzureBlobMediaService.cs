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
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplCommerce.Module.StorageAzureBlob
{
    public class AzureBlobMediaService : IMediaService
    {
        private const string REGEX_ACCOUNT_NAME = @"[\w\d;=\/+.]*AccountName=([^;]+);[\w\d;=\/+.]*";

        private readonly string _storageConnectionString;
        private readonly string _storageContainer;
        private readonly bool _retryOnFailure;
        private readonly string _publicEndpoint;

        public AzureBlobMediaService(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetValue("Azure:Blob:StorageConnectionString", string.Empty);
            _storageContainer = configuration.GetValue("Azure:Blob:StorageContainer", string.Empty);
            _retryOnFailure = configuration.GetValue("Azure:Blob:RetryOnFailure", false);
            _publicEndpoint = configuration.GetValue("Azure:Blob:PublicEndpoint", string.Empty);

            Contract.Requires(string.IsNullOrWhiteSpace(_storageConnectionString));
            Contract.Requires(string.IsNullOrWhiteSpace(_storageContainer));

            if (string.IsNullOrWhiteSpace(_publicEndpoint))
            {
                var result = Regex.Match(_storageConnectionString, REGEX_ACCOUNT_NAME, RegexOptions.Singleline | RegexOptions.Compiled);

                if (!result.Success)
                    throw new ArgumentException("StorageConnectionString in wrong format");

                string accountName = result.Groups[1].Value;
                _publicEndpoint = $"https://{accountName}.blob.core.windows.net/{_storageContainer}/";
            }
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
            return GetMediaUrl(media.FileName);
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
            await container.CreateIfNotExistsAsync(BlobContainerPublicAccessType.Container, requestOptions, null);
            return container.GetBlockBlobReference(blobName);
        }
    }
}