using Dashboard.Domain.Common;

namespace Dashboard.Domain.Entities
{
    public class Team : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }
    }
}
