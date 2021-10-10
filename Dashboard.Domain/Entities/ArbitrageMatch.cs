using Dashboard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class ArbitrageMatch : AuditEntity
    {
        public Guid Id { get; set; }
        public string MatchName { get; set; }
        //todo: to see how to manage these better without sending the matchName
        //private string matchName;
        //public string MatchName { 
        //    get
        //    {
        //        return this.matchName;
        //    }

        //    set
        //    {
        //        this.matchName = HomeTeam.Name + " vs " + AwayTeam.Name;
        //    }
        //}
        public int StateId { get; set; }
        public State State { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
