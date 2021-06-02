using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Sports.Commands
{
    public class DeleteSportCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSportCommandHandler : IRequestHandler<DeleteSportCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteSportCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sports
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Sport), request.Id);
            }

            _context.Sports.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
