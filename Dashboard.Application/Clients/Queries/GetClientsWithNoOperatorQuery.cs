using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Clients.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Dashboard.Application.Clients.Queries
{
    public class GetClientsWithNoOperatorQuery : IRequest<IList<ClientVM>>
    {
    }

    public class GetClientsWithNoOperatorQueryHandler : IRequestHandler<GetClientsWithNoOperatorQuery, IList<ClientVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsWithNoOperatorQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<ClientVM>> Handle(GetClientsWithNoOperatorQuery request, CancellationToken cancellationToken)
        {
            var result = new List<ClientVM>();
            var Clients = await _context.Clients.Where(c => c.OperatorId == null).ToListAsync(cancellationToken);

            if (Clients != null)
            {
                result = _mapper.Map<List<ClientVM>>(Clients);
            }

            return result;
        }
    }
}
