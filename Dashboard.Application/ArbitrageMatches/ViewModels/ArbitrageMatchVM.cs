using Dashboard.Application.Leagues.ViewModels;
using Dashboard.Application.Sports.ViewModels;
using Dashboard.Application.Teams.ViewModels;
using System;

namespace Dashboard.Application.ArbitrageMatches.ViewModels
{
    public class ArbitrageMatchVM
    {
        public Guid Id { get; set; }
        public string MatchName { get; set; }
        public SportVM Sport { get; set; }
        public LeagueVM League { get; set; }
        public TeamVM HomeTeam { get; set; }
        public TeamVM AwayTeam { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
