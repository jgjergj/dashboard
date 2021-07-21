using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Leagues.Commands
{
    public class CreateLeagueCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public int SportId { get; set; }
    }

    public class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateLeagueCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<League>(request);

            _context.Leagues.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
