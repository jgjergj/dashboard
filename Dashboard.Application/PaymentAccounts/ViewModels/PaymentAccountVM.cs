using Dashboard.Application.Companies.ViewModels;
using Dashboard.Application.Sports.ViewModels;
using Dashboard.Application.States.ViewModels;
using Dashboard.Application.Statuses.ViewModels;
using System;

namespace Dashboard.Application.PaymentAccounts.ViewModels
{
    public class PaymentAccountVM
    {
        public int Id { get; set; }
        public SportVM Sport { get; set; }
        public CompanyVM Company { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public StateVM State { get; set; }
        public StatusVM Status { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DocumentExpiry { get; set; }
    }
}
