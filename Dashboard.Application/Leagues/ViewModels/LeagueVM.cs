using Dashboard.Application.Sports.ViewModels;
using Dashboard.Application.States.ViewModels;

namespace Dashboard.Application.Leagues.ViewModels
{
    public class LeagueVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateVM State { get; set; }
        public SportVM Sport { get; set; }
    }
}
