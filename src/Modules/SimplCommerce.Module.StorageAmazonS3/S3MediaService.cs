using SimplCommerce.Module.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Module.Core.Models;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;

namespace SimplCommerce.Module.StorageAmazonS3
{
    public class S3MediaService : IMediaService
    {
        private IAmazonS3 _amazonS3Client;
        private string _bucketName = "simpl-user-content";
        public S3MediaService()
        {

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
            throw new NotImplementedException();
        }

        public string GetMediaUrl(string fileName)
        {
            throw new NotImplementedException();
        }

        public string GetThumbnailUrl(Media media)
        {
            throw new NotImplementedException();
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var putObjectRequest = new PutObjectRequest
            {
                BucketName = "simpl-user-content",
                Key = fileName,
                InputStream = mediaBinaryStream
            };

            var response = await _amazonS3Client.PutObjectAsync(putObjectRequest);
        }
    }
}
