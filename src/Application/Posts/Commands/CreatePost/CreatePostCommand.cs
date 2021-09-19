using Application.Common.Interfaces;
using Application.Common.Security;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Posts.Commands.CreatePost
{
    [Authorize]
    public class CreatePostCommand : IRequest<int>
    {
        public string Caption { get; internal set; }
        public string Image { get; internal set; }
    }
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public CreatePostCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _context = context;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Caption = request.Caption,
                CreatedAt = _dateTime.Now,
                CreatorId = _currentUserService.AccountId,
                Image = request.Image,
            };
            _context.Posts.Add(post);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
