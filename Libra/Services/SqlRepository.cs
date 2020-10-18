using Libra.Library.Models;
using Libra.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libra.Services
{
    public class SqlRepository : IRepository
    {
        private readonly AppConnect db;

        public SqlRepository(AppConnect db)
        {
            this.db = db;
        }

        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }

        public List<Inventory> GetInventories()
        {
            return db.Inventories.ToList();
        }

        public List<Stock> GetStocks()
        {
            return db.Stocks.ToList();
        }

        public List<Warehouse> GetWarehouses()
        {
            return db.Warehouses.ToList();
        }
    }
}
