using Dashboard.Domain.Entities;

namespace Dashboard.Application.Leagues.ViewModels
{
    public class LeagueVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }
        public Sport Sport { get; set; }
    }
}
