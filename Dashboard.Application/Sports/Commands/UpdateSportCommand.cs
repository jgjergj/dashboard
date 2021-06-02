using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Sports.Commands
{
    public class UpdateSportCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateSportCommandHandler : IRequestHandler<UpdateSportCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateSportCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Sports.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Sports), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
