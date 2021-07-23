using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Operators.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Operators.Queries
{
    public class GetOperatorsQuery : IRequest<IList<OperatorVM>>
    {
    }

    public class GetOperatorsQueryHandler : IRequestHandler<GetOperatorsQuery, IList<OperatorVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<OperatorVM>> Handle(GetOperatorsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<OperatorVM>();
            var Operators = await _context.Operators.Include(o => o.Department).ToListAsync(cancellationToken);

            if (Operators != null)
            {
                result = _mapper.Map<List<OperatorVM>>(Operators);
            }

            return result;
        }
    }
}
