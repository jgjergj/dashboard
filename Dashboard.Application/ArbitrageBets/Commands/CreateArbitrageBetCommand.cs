using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.ArbitrageBets.Commands
{
    public class CreateArbitrageBetCommand : IRequest<int>
    {
        public Guid ArbitrageMatchId { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public string Line { get; set; }
        public int StatusId { get; set; }
        public double Stake { get; set; }
        public double Odd { get; set; }
        public double Return { get; set; }
        public double Profit { get; set; }
        public double ProfitARB { get; set; }
        public int TypeId { get; set; }
    }

    public class CreateArbitrageBetComandHandler : IRequestHandler<CreateArbitrageBetCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateArbitrageBetComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateArbitrageBetCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ArbitrageBet>(request);

            _context.ArbitrageBets.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
