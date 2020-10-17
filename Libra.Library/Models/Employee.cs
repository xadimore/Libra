using System;
using System.Collections.Generic;
using System.Text;

namespace Libra.Library.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
