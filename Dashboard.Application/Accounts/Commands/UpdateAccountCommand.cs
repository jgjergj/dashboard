using AutoMapper;
using Dashboard.Application.Common.Exceptions;
using Dashboard.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Accounts.Commands
{
    public class UpdateAccountCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CompanyId { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CurrencyId { get; set; }
        public DateTime OpeningDate { get; set; }
        public string LoginLink { get; set; }
        public int StatusId { get; set; }
        public int TypeId { get; set; }
        public int StateId { get; set; }
        public int OperatorId { get; set; }
        public int PaymentAccountId { get; set; }
    }

    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Accounts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Accounts), request.Id);
            }

            _mapper.Map(request, entity);

            //todo: use AutoMapper here
            //entity.Name = request.Name;
            //entity.Surname = request.Surname;
            //entity.CompanyId = request.CompanyId;
            //entity.Balance = request.Balance;
            //entity.Email = request.Email;
            //entity.Username = request.Username;
            //entity.Password = request.Password;
            //entity.Birthday = request.Birthday;
            //entity.Address = request.Address;
            //entity.Phone = request.Phone;
            //entity.CurrencyId = request.CurrencyId;
            //entity.OpeningDate = request.OpeningDate;
            //entity.LoginLink = request.LoginLink;
            //entity.StatusId = request.StatusId;
            //entity.TypeId = request.TypeId;
            //entity.StateId = request.StateId;
            //entity.OperatorId = request.OperatorId;
            //entity.PaymentAccountId = request.PaymentAccountId;

        await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
