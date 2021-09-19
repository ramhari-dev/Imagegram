using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Comments.Commands.AddComment
{
    public class AddCommentCommand : IRequest<int>
    {
        public string Content { get; set; }
        public string PostId { get; set; }
    }
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public AddCommentCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService, IDateTime datetime)
        {
            _context = context;
            _currentUserService = currentUserService;
            _dateTime = datetime;
        }
        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            _context.Comments.Add(new Comment
            {
                Content = request.Content,
                CreatedAt = _dateTime.Now,
                CreatorId = _currentUserService.AccountId,
                PostId = request.PostId
            });
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
