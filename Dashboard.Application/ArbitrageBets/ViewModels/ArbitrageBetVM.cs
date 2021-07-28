using Dashboard.Application.Accounts.ViewModels;
using Dashboard.Application.Companies.ViewModels;
using Dashboard.Application.Statuses.ViewModels;
using Dashboard.Application.Types.ViewModels;
using System;

namespace Dashboard.Application.ArbitrageBets.ViewModels
{
    public class ArbitrageBetVM
    {
        public int Id { get; set; }
        //public ArbitrageMatchVM ArbitrageMatch { get; set; }
        public CompanyVM Company { get; set; }
        public AccountVM Account { get; set; }
        public string Line { get; set; }
        public StatusVM Status { get; set; }
        public double Stake { get; set; }
        public double Odd { get; set; }
        public double Return { get; set; }
        public double Profit { get; set; }
        public double ProfitARB { get; set; }
        public TypeVM Type { get; set; }
    }
}
