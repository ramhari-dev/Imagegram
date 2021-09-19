using Application.Common.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts.Query.GetPosts
{
    [Authorize]
    public class GetPostsQuery : IRequest<GetPostsResult>
    {
    }
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, GetPostsResult>
    {
        public Task<GetPostsResult> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
