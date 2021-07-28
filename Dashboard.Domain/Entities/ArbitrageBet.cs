using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class ArbitrageBet
    {
        public int Id { get; set; }
        public Guid ArbitrageMatchId { get; set; }
        public ArbitrageMatch ArbitrageMatch { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public string Line { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public double Stake { get; set; }
        public double Odd { get; set; }
        public double Return { get; set; }
        public double Profit { get; set; }
        public double ProfitARB { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
