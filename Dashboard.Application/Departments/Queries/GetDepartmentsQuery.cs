using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Departments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Departments.Queries
{
    public class GetDepartmentsQuery : IRequest<IList<DepartmentVM>>
    {
    }

    public class GetDepartmentsQueryHandler : IRequestHandler<GetDepartmentsQuery, IList<DepartmentVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<DepartmentVM>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var result = new List<DepartmentVM>();
            var departments = await _context.Departments.ToListAsync(cancellationToken);

            if (departments != null)
            {
                result = _mapper.Map<List<DepartmentVM>>(departments);
            }

            return result;
        }
    }
}
