using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Types.Commands
{
    public class DeleteTypeCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteTypeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Types
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Type), request.Id);
            }

            _context.Types.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
