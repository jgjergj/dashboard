using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Domain.Common
{
    public class AuditEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
