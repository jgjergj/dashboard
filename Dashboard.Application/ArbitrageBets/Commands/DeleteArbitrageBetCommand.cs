using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageBets.Commands
{
    public class DeleteArbitrageBetCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteArbitrageBetCommandHandler : IRequestHandler<DeleteArbitrageBetCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteArbitrageBetCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteArbitrageBetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ArbitrageBets
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ArbitrageBet), request.Id);
            }

            _context.ArbitrageBets.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
