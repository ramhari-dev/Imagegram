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

namespace Application.Accounts.Commands.DeleteAccount
{
    [Authorize]
    public class DeleteAccountCommand : IRequest<int>
    {
    }
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public DeleteAccountCommandHandler(IApplicationDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }
        public async Task<int> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == _currentUserService.AccountId);
            _context.Accounts.Remove(account);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
