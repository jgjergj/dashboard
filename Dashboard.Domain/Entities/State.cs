using Dashboard.Domain.Common;
using System.Collections.Generic;

namespace Dashboard.Domain.Entities
{
    public class State : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<StateSport> StateSports { get; set; }
    }
}
