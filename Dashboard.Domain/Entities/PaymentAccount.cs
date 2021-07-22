using Dashboard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class PaymentAccount: AuditEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DocumentExpiry { get; set; }
        
    }
}
