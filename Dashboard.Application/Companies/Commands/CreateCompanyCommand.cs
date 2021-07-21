using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Application.Types.ViewModels;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Companies.Commands
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LoginLink { get; set; }
        public int TypeId { get; set; }
    }

    public class CreateCompanyComandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCompanyComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Company>(request);

            _context.Companies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
