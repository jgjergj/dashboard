using Dashboard.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Domain.Entities
{
    public class Operator : AuditEntity
    {
        public Operator()
        {
            this.Clients = new List<Client>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }        
        public List<Client> Clients { get; set; }

        //public int DepartmentId { get; set; }
        //public Department DepartmentId { get; set; }

        //accounts
        //transfers
    }

}
