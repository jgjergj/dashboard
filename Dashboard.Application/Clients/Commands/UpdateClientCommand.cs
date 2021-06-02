using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Clients.Commands
{
    public class UpdateClientCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateClientCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Clients), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Balance = request.Balance;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
