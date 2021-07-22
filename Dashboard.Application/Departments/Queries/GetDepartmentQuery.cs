using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Departments.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Departments.Queries
{
    public class GetDepartmentQuery : IRequest<DepartmentVM>
    {
        public int Id { get; set; }

        public GetDepartmentQuery(int id)
        {
            Id = id;
        }
    }

    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, DepartmentVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<DepartmentVM> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = new DepartmentVM();
            var department = await _context.Departments.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (department != null)
            {
                result = _mapper.Map<DepartmentVM>(department);
            }

            return result;
        }
    }
}
