using System.Diagnostics.Contracts;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.StorageAmazonS3
{
    public class S3MediaService : IMediaService
    {
        private IAmazonS3 _amazonS3Client;
        private string _bucketName;
        private string _publicEndpoint;

        public S3MediaService(IConfiguration configuration)
        {
            var regionEndpointName = configuration["AWS:S3:RegionEndpointName"];
            var accessKeyId = configuration["AWS:S3:AccessKeyId"];
            var secretAccessKey = configuration["AWS:S3:SecretAccessKey"];
            _bucketName = configuration["AWS:S3:BucketName"];
            _publicEndpoint = configuration["AWS:S3:PublicEndpoint"];

            Contract.Requires(string.IsNullOrWhiteSpace(regionEndpointName));
            Contract.Requires(string.IsNullOrWhiteSpace(accessKeyId));
            Contract.Requires(string.IsNullOrWhiteSpace(secretAccessKey));
            Contract.Requires(string.IsNullOrWhiteSpace(_bucketName));

            _amazonS3Client = new AmazonS3Client(accessKeyId, secretAccessKey, RegionEndpoint.GetBySystemName(regionEndpointName));

            if (string.IsNullOrWhiteSpace(_publicEndpoint))
            {
                _publicEndpoint = $"http://s3.{regionEndpointName}.amazonaws.com/{_bucketName}/";
            }
        }

        public Task DeleteMediaAsync(Media media)
        {
            return DeleteMediaAsync(media.FileName);
        }

        public async Task DeleteMediaAsync(string fileName)
        {
            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = fileName,
            };

            await _amazonS3Client.DeleteObjectAsync(deleteObjectRequest);
        }

        public string GetMediaUrl(Media media)
        {
            return string.Concat(_publicEndpoint, media.FileName);
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
            var uploadRequest = new TransferUtilityUploadRequest
            {
                BucketName = _bucketName,
                Key = fileName,
                CannedACL = S3CannedACL.PublicRead,
                InputStream = mediaBinaryStream
            };

            var transferUtility = new TransferUtility(_amazonS3Client);
            await transferUtility.UploadAsync(uploadRequest);
        }
    }
}
