using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Libra.Models;
using Libra.Services;

namespace Libra.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository repository;

        public HomeController(ILogger<HomeController> logger,
            IRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var stocks = repository.GetStocks().Count();
            var warehouse = repository.GetWarehouses().Count();
            var inventory = repository.GetInventories().Count();
            var employee = repository.GetEmployees().Count();

            ViewBag.Stocks = stocks;
            ViewBag.WareHouse = warehouse;
            ViewBag.Inventory = inventory;
            ViewBag.Employee = employee;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
