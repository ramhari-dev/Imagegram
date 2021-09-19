using Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<CreateAccountResult>
    {
        public string Name { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, CreateAccountResult>
    {
        private readonly IApplicationDbContext _context;

        public CreateAccountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateAccountResult> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Account
            {
                Name = request.Name
            };
            _context.Accounts.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateAccountResult
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
