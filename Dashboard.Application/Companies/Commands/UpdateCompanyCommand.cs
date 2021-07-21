using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Companies.Commands
{
    public class UpdateCompanyCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string LoginLink { get; set; }
        public int TypeId { get; set; }
    }

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IAppDbContext _context;

        public UpdateCompanyCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Companies), request.Id);
            }

            //todo: use AutoMapper here
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.LoginLink = request.LoginLink;
            entity.TypeId = request.TypeId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
