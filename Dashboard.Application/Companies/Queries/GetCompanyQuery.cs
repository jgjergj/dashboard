using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Companies.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Companies.Queries
{
    public class GetCompanyQuery : IRequest<CompanyVM>
    {
        public int Id { get; set; }

        public GetCompanyQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyVM>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCompanyQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<CompanyVM> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var result = new CompanyVM();
            var Company = await _context.Companies.FirstAsync(s => s.Id == request.Id); // ToListAsync(cancellationToken);

            if (Company != null)
            {
                result = _mapper.Map<CompanyVM>(Company);
            }

            return result;
        }
    }
}
