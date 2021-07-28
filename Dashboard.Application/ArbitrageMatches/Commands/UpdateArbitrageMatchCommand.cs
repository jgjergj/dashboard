using AutoMapper;
using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageMatches.Commands
{
    public class UpdateArbitrageMatchCommand : IRequest
    {
        public Guid Id { get; set; }
        public int LeagueId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateArbitrageMatchCommandHandler : IRequestHandler<UpdateArbitrageMatchCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateArbitrageMatchCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateArbitrageMatchCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ArbitrageMatches.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ArbitrageMatches), request.Id);
            }

            _mapper.Map(request, entity);            

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
