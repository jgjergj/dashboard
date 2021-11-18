using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Common.Utils;
using Dashboard.Application.Sports.ViewModels;
using Dashboard.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Sports.Queries
{
    public class GetSportsQuery : IRequest<IList<SportVM>>
    {
        public string FilterBy { get; set; }
        public string Value { get; set; }

        public GetSportsQuery(string FilterBy, string Value)
        {
            this.FilterBy = FilterBy;
            this.Value = Value;
        }
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
            IQueryable<Sport> sportsQuery = _context.Sports.Include(m => m.State).AsQueryable();

            if (!string.IsNullOrEmpty(request.FilterBy))
            {
                var predicate = Utils.CreatePredicate<Sport>(request.FilterBy, request.Value);
                sportsQuery = sportsQuery.Where(predicate);
            }

            var leagues = await sportsQuery.ToListAsync(cancellationToken);


            if (leagues != null)
            {
                result = _mapper.Map<List<SportVM>>(leagues);
            }

            return result;
        }
    }
}
