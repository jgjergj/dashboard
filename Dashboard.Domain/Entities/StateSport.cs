using Dashboard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class StateSport: AuditEntity
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
