using Application.Common.Interfaces;
using Application.Common.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts.Query.GetPostImageUrl
{
    [Authorize]
    public class GetPostImageUrlQuery : IRequest<GetPostImageUrlResult>
    {
        public string ImageName { get; set; }
    }
    public class GetPostImageUrlQueryHandler : IRequestHandler<GetPostImageUrlQuery, GetPostImageUrlResult>
    {
        private readonly IAmazonS3BucketService _s3BucketService;

        public GetPostImageUrlQueryHandler(IAmazonS3BucketService s3BucketService)
        {
            _s3BucketService = s3BucketService;
        }
        public async Task<GetPostImageUrlResult> Handle(GetPostImageUrlQuery request, CancellationToken cancellationToken)
        {
            return await _s3BucketService.GeneratePresignedUrl(request);
        }
    }
}
