using Dashboard.Domain.Common;

namespace Dashboard.Domain.Entities
{
    public class Type : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Environment { get; set; }
    }
}
