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
    }
    public class GetPostImageUrlQueryHandler : IRequestHandler<GetPostImageUrlQuery, GetPostImageUrlResult>
    {
        public Task<GetPostImageUrlResult> Handle(GetPostImageUrlQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
