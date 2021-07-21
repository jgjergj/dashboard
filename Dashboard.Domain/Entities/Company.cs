using Dashboard.Domain.Common;

namespace Dashboard.Domain.Entities
{
    public class Company: AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LoginLink { get; set; }
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
