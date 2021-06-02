using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Currencies.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Currencies.Queries
{
    public class GetCurrencyQuery : IRequest<CurrencyVM>
    {
        public int Id { get; set; }

        public GetCurrencyQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCurrencyQueryHandler : IRequestHandler<GetCurrencyQuery, CurrencyVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCurrencyQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<CurrencyVM> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
        {
            var result = new CurrencyVM();
            var Currency = await _context.Currencies.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Currency != null)
            {
                result = _mapper.Map<CurrencyVM>(Currency);
            }

            return result;
        }
    }
}
