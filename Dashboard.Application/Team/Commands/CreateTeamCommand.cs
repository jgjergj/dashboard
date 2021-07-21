using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Teams.Commands
{
    public class CreateTeamCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public int SportId { get; set; }
        public int LeagueId { get; set; }
    }

    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateTeamCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Team>(request);

            _context.Teams.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
