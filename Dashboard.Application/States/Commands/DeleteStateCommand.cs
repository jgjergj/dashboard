using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.States.Commands
{
    public class DeleteStateCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteStateCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.States
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(State), request.Id);
            }

            _context.States.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
