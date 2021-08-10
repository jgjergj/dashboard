using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageMatches.Commands
{
    public class CreateArbitrageMatchCommand : IRequest<Guid>
    {
        public int SportId { get; set; }
        public int LeagueId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string MatchName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateArbitrageMatchComandHandler : IRequestHandler<CreateArbitrageMatchCommand, Guid>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateArbitrageMatchComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<Guid> Handle(CreateArbitrageMatchCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ArbitrageMatch>(request);

            _context.ArbitrageMatches.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
