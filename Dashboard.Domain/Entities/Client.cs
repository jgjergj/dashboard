using Dashboard.Domain.Common;

namespace Dashboard.Domain.Entities
{
    public class Client : AuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Balance { get; set; }
        public int? OperatorId { get; set; }
        public Operator Operator { get; set; }
    }
}
