using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.PaymentAccounts.Commands
{
    public class DeletePaymentAccountCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePaymentAccountCommandHandler : IRequestHandler<DeletePaymentAccountCommand>
    {
        private readonly IAppDbContext _context;

        public DeletePaymentAccountCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePaymentAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentAccounts
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentAccount), request.Id);
            }

            _context.PaymentAccounts.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
