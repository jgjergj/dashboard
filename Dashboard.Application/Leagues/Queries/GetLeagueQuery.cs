using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Leagues.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Leagues.Queries
{
    public class GetLeagueQuery : IRequest<LeagueVM>
    {
        public int Id { get; set; }

        public GetLeagueQuery(int id)
        {
            Id = id;
        }
    }

    public class GetLeagueQueryHandler : IRequestHandler<GetLeagueQuery, LeagueVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetLeagueQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<LeagueVM> Handle(GetLeagueQuery request, CancellationToken cancellationToken)
        {
            var result = new LeagueVM();
            var League = await _context.Leagues.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (League != null)
            {
                result = _mapper.Map<LeagueVM>(League);
            }

            return result;
        }
    }
}
