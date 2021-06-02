using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Currencies.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Currencies.Queries
{
    public class GetCurrenciesQuery : IRequest<IList<CurrencyVM>>
    {
    }

    public class GetCurrenciesQueryHandler : IRequestHandler<GetCurrenciesQuery, IList<CurrencyVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCurrenciesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<CurrencyVM>> Handle(GetCurrenciesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CurrencyVM>();
            var Currencies = await _context.Currencies.ToListAsync(cancellationToken);

            if (Currencies != null)
            {
                result = _mapper.Map<List<CurrencyVM>>(Currencies);
            }

            return result;
        }
    }
}
