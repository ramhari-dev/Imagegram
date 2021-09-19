using Application.Posts.Query.GetPostImageUrl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAmazonS3BucketService
    {
        Task<GetPostImageUrlResult> GeneratePresignedUrl(GetPostImageUrlQuery request);
    }
}
