using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Currencies.Commands
{
    public class DeleteCurrencyCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteCurrencyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.Id);
            }

            _context.Currencies.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
