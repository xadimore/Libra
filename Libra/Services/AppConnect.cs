using Libra.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libra.Services
{
    public class AppConnect : DbContext
    {
        public AppConnect(DbContextOptions<AppConnect> options) : base(options)
        {
        }


        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}
