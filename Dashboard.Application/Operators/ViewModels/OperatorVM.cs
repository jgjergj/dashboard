using Dashboard.Application.Clients.ViewModels;
using Dashboard.Application.Departments.ViewModels;
using System.Collections.Generic;

namespace Dashboard.Application.Operators.ViewModels
{
    public class OperatorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public DepartmentVM Department { get; set; }
        //public List<ClientVM> Clients { get; set; }
    }
}
