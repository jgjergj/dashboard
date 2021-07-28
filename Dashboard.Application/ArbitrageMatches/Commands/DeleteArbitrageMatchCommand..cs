using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageMatches.Commands
{
    public class DeleteArbitrageMatchCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteArbitrageMatchCommandHandler : IRequestHandler<DeleteArbitrageMatchCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteArbitrageMatchCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteArbitrageMatchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ArbitrageMatches
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ArbitrageMatch), request.Id);
            }

            _context.ArbitrageMatches.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
