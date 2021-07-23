using AutoMapper;
using Dashboard.Application.Common.Interfaces;
using Dashboard.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dashboard.Application.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
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

    public class CreateAccountComandHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateAccountComandHandler(IAppDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Account>(request);

            _context.Accounts.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
