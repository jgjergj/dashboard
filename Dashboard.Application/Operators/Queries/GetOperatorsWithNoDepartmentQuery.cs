using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Dashboard.Application.Operators.ViewModels;

namespace Dashboard.Application.Operators.Queries
{
    public class GetOperatorsWithNoDepartmentQuery : IRequest<IList<OperatorVM>>
    {
    }

    public class GetOperatorsWithNoDepartmentQueryHandler : IRequestHandler<GetOperatorsWithNoDepartmentQuery, IList<OperatorVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOperatorsWithNoDepartmentQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<OperatorVM>> Handle(GetOperatorsWithNoDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = new List<OperatorVM>();
            var operators = await _context.Operators.Where(c => c.DepartmentId == null).ToListAsync(cancellationToken);

            if (operators != null)
            {
                result = _mapper.Map<List<OperatorVM>>(operators);
            }

            return result;
        }
    }
}
