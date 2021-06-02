using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Sports.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Sports.Queries
{
    public class GetSportsQuery : IRequest<IList<SportVM>>
    {
    }

    public class GetSportsQueryHandler : IRequestHandler<GetSportsQuery, IList<SportVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSportsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<SportVM>> Handle(GetSportsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<SportVM>();
            var Sports = await _context.Sports.ToListAsync(cancellationToken);

            if (Sports != null)
            {
                result = _mapper.Map<List<SportVM>>(Sports);
            }

            return result;
        }
    }
}
