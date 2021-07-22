using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.PaymentAccounts.Commands
{
    public class UpdatePaymentAccountCommand : IRequest
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StateId { get; set; }
        public int StatusId { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DocumentExpiry { get; set; }

    }

    public class UpdatePaymentAccountCommandHandler : IRequestHandler<UpdatePaymentAccountCommand>
    {
        private readonly IAppDbContext _context;

        public UpdatePaymentAccountCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePaymentAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PaymentAccounts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(PaymentAccounts), request.Id);
            }

            //todo: use AutoMapper here
            entity.Id = request.Id;
            entity.CompanyId = request.CompanyId;
            entity.Username = request.Username;
            entity.Email = request.Email;
            entity.Password = request.Password;
            entity.StateId = request.StateId;
            entity.StatusId = request.StatusId;
            entity.Balance = request.Balance;
            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Address = request.Address;
            entity.Phone = request.Phone;
            entity.DocumentExpiry = request.DocumentExpiry;


        await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
