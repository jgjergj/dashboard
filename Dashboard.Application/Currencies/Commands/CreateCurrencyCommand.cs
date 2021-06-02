using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Currencies.Commands
{
    public class CreateCurrencyCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class CreateCurrencyComandHandler : IRequestHandler<CreateCurrencyCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateCurrencyComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Currency>(request);

            _context.Currencies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
