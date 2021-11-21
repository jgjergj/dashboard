using Dashboard.Domain.Common;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class Sport : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StateSport> StatesSports { get; set; }
    }
}
