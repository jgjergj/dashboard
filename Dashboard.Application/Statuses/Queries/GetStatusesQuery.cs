using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Statuses.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Statuses.Queries
{
    public class GetStatusesQuery : IRequest<IList<StatusVM>>
    {
    }

    public class GetStatusesQueryHandler : IRequestHandler<GetStatusesQuery, IList<StatusVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetStatusesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<StatusVM>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<StatusVM>();
            var Statuses = await _context.Statuses.ToListAsync(cancellationToken);

            if (Statuses != null)
            {
                result = _mapper.Map<List<StatusVM>>(Statuses);
            }

            return result;
        }
    }
}
