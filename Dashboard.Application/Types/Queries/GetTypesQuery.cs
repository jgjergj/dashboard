using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Types.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Types.Queries
{
    public class GetTypesQuery : IRequest<IList<TypeVM>>
    {
    }

    public class GetTypesQueryHandler : IRequestHandler<GetTypesQuery, IList<TypeVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTypesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<TypeVM>> Handle(GetTypesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<TypeVM>();
            var Types = await _context.Types.ToListAsync(cancellationToken);

            if (Types != null)
            {
                result = _mapper.Map<List<TypeVM>>(Types);
            }

            return result;
        }
    }
}
