using AutoMapper;
using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageBets.Commands
{
    public class UpdateArbitrageBetCommand : IRequest
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int? AccountId { get; set; }
        public string? Line { get; set; }
        public int? StatusId { get; set; }
        public double? Stake { get; set; }
        public double? Odd { get; set; }
        public double? Return { get; set; }
        public double? Profit { get; set; }
        public double? ProfitARB { get; set; }
        public int? TypeId { get; set; }
    }

    public class UpdateArbitrageBetCommandHandler : IRequestHandler<UpdateArbitrageBetCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateArbitrageBetCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateArbitrageBetCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ArbitrageBets.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ArbitrageBets), request.Id);
            }

            if (request.AccountId == null)
            {
                request.AccountId = entity.AccountId;
            }

            if (request.CompanyId == null)
            {
                request.CompanyId = entity.CompanyId;
            }

            if (request.StatusId == null)
            {
                request.StatusId = entity.StatusId;
            }

            if (request.TypeId == null)
            {
                request.TypeId = entity.TypeId;
            }

            _mapper.Map(request, entity);            

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
