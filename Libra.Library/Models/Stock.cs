using System;
using System.Collections.Generic;
using System.Text;

namespace Libra.Library.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string StockName { get; set; }
        public ICollection<Inventory> Inventory { get; set; }
    }
}
