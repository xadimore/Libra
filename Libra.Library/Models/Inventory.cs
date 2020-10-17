using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Libra.Library.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [DisplayName("Date")]
        public DateTime DateRecieved { get; set; }
        public int Units { get; set; }
        public int StockId { get; set; }
        public int WarehouseId { get; set; }
        public int EmployeeId { get; set; }
        public Stock Stock { get; set; }
        public Warehouse Warehouse { get; set; }
        public Employee Employee { get; set; }

    }
}
