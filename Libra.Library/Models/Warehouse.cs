using System;
using System.Collections.Generic;
using System.Text;

namespace Libra.Library.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
