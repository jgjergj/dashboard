using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Leagues.Commands
{
    public class DeleteLeagueCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteLeagueCommandHandler : IRequestHandler<DeleteLeagueCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteLeagueCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteLeagueCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Leagues
                .Where(s => s.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(League), request.Id);
            }

            _context.Leagues.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
