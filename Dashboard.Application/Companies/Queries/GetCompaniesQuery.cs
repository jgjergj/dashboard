using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Companies.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Companies.Queries
{
    public class GetCompaniesQuery : IRequest<IList<CompanyVM>>
    {
    }

    public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, IList<CompanyVM>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IList<CompanyVM>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            var result = new List<CompanyVM>();
            var Companies = await _context.Companies.ToListAsync(cancellationToken);

            if (Companies != null)
            {
                result = _mapper.Map<List<CompanyVM>>(Companies);
            }

            return result;
        }
    }
}
