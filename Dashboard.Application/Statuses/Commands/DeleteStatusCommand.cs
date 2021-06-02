using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Statuses.Commands
{
    public class DeleteStatusCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteStatusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Statuses
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Status), request.Id);
            }

            _context.Statuses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
