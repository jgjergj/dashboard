using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Sports.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Sports.Queries
{
    public class GetSportQuery : IRequest<SportVM>
    {
        public int Id { get; set; }

        public GetSportQuery(int id)
        {
            Id = id;
        }
    }

    public class GetSportQueryHandler : IRequestHandler<GetSportQuery, SportVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSportQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<SportVM> Handle(GetSportQuery request, CancellationToken cancellationToken)
        {
            var result = new SportVM();
            var Sport = await _context.Sports.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Sport != null)
            {
                result = _mapper.Map<SportVM>(Sport);
            }

            return result;
        }
    }
}
