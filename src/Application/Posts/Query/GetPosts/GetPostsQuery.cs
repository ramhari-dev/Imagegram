using Application.Common.Interfaces;
using Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts.Query.GetPosts
{
    [Authorize]
    public class GetPostsQuery : IRequest<GetPostsResult>
    {
        public int Count { get; set; } = 50;
        public int Cursor { get; set; }
    }
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, GetPostsResult>
    {
        private readonly IApplicationDbContext _context;

        public GetPostsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GetPostsResult> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            if(request.Cursor  == 0)
            {
                var lastItem = (_context.Posts.LastOrDefault());
                request.Cursor = lastItem == null? 0 : lastItem.Id;
            }
            var employees = await _context.Posts
                .Include(x=>x.Comments)
                .Include(x=>x.Creator)
                .OrderByDescending(x => x.Id)
                .Where(x => x.Id < request.Cursor)
                .Take(request.Count)
                .ToListAsync();
            return new GetPostsResult
            {
                NextCursor = Convert.ToInt32(employees.LastOrDefault()?.Id),
                Data = employees
            };
            
        }
    }
}
