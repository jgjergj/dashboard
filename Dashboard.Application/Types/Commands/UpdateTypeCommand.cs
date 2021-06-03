using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Types.Commands
{
    public class UpdateTypeCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Environment { get; set; }
    }

    public class UpdateTypeCommandHandler : IRequestHandler<UpdateTypeCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateTypeCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Types.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Types), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Environment = request.Environment;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
