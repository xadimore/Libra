using Libra.Library.Models;
using Libra.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libra.Services
{
    public interface IRepository
    {
        List<Inventory> GetInventories();
        List<Employee> GetEmployees();
        List<Warehouse> GetWarehouses();
        List<Stock> GetStocks();
    }
}
