using Dashboard.Domain.Common;

namespace Dashboard.Domain.Entities
{
    public class State : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
