using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Currencies.Commands
{
    public class UpdateCurrencyCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
    }

    public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateCurrencyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currencies), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Code = request.Code;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
