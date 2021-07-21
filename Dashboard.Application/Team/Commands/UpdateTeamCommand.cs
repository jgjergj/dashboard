using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Teams.Commands
{
    public class UpdateTeamCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int StateId { get; set; }
        public int SportId { get; set; }
        public int LeagueId { get; set; }
    }

    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateTeamCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Teams.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Teams), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.StateId = request.StateId;
            entity.SportId = request.SportId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
