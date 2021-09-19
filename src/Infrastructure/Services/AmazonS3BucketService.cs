using Amazon.S3;
using Amazon.S3.Model;
using Application.Common.Interfaces;
using Application.Posts.Query.GetPostImageUrl;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AmazonS3BucketService : IAmazonS3BucketService
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly IConfiguration _configuration;

        public AmazonS3BucketService(IAmazonS3 amazonS3, IConfiguration configuration)
        {
            _amazonS3 = amazonS3;
            _configuration = configuration;
        }
        public async Task<GetPostImageUrlResult> GeneratePresignedUrl(GetPostImageUrlQuery request)
        {
            return await Task.Run(() => {
                var ext = request.ImageName.Split('.').LastOrDefault().ToLower();
                var key = $"{Guid.NewGuid()}.jpg";
                if (ext == "jpg" || ext == "jpeg" || ext == "png" || ext == "bmp")
                {
                    var url = _amazonS3.GetPreSignedURL(new GetPreSignedUrlRequest
                    {
                        BucketName = _configuration["S3BucketName"],
                        Key = key
                    });
                    return new GetPostImageUrlResult
                    {
                        ImageName = key,
                        URL = url
                    };
                }
                return null;
            });
        }
    }
}
