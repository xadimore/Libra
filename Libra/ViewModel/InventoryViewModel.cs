using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Libra.ViewModel
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public DateTime DateRecieved { get; set; }

        [DisplayName("Stock Name")]
        public string StockName { get; set; }
        public string  Location { get; set; }
        public int Unit { get; set; }

        [DisplayName("Posted By")]
        public string Employee { get; set; }
    }
}
