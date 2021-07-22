using Dashboard.Domain.Common;

namespace Dashboard.Domain.Entities
{
    public class Department : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
