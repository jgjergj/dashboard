using Dashboard.Domain.Common;
using System;

namespace Dashboard.Domain.Entities
{
    public class Account : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public DateTime OpeningDate { get; set; }
        public string LoginLink { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public int PaymentAccountId { get; set; }
        public PaymentAccount PaymentAccount { get; set; }
    }
}
