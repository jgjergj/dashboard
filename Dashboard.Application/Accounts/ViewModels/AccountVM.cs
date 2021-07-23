using Dashboard.Application.Companies.ViewModels;
using Dashboard.Application.Currencies.ViewModels;
using Dashboard.Application.Operators.ViewModels;
using Dashboard.Application.PaymentAccounts.ViewModels;
using Dashboard.Application.States.ViewModels;
using Dashboard.Application.Statuses.ViewModels;
using Dashboard.Application.Types.ViewModels;
using System;

namespace Dashboard.Application.Accounts.ViewModels
{
    public class AccountVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CompanyVM Company { get; set; }
        public double Balance { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public CurrencyVM Currency { get; set; }
        public DateTime OpeningDate { get; set; }
        public string LoginLink { get; set; }
        public StatusVM Status { get; set; }
        public TypeVM Type { get; set; }
        public StateVM State { get; set; }
        public OperatorVM Operator { get; set; }
        public PaymentAccountVM PaymentAccount { get; set; }
    }
}
