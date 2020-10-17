using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Libra.Library.Models;
using Libra.Services;
using Libra.ViewModel;

namespace Libra.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly AppConnect _context;

        public InventoriesController(AppConnect context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var appConnect = _context.Inventories.Include(i => i.Employee).Include(i => i.Stock).Include(i => i.Warehouse).Select( b => new InventoryViewModel 
            { 
            Id = b.Id,
            DateRecieved = b.DateRecieved,
            Employee = b.Employee.Name,
            StockName = b.Stock.StockName,
            Location = b.Warehouse.Location,
            Unit = b.Units
            
            });
            return View(await appConnect.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .Include(i => i.Employee)
                .Include(i => i.Stock)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employees, "Name", "Name");
            ViewData["StockName"] = new SelectList(_context.Stocks, "StockName", "StockName");
            ViewData["Location"] = new SelectList(_context.Warehouses, "Location", "Location");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryViewModel inventoryView)
        {
            if (ModelState.IsValid)
            {
                var EmployeeId = _context.Employees.Where(e => e.Name == inventoryView.Employee).Select(e => e.EmployeeId).FirstOrDefault();
                var StockId = _context.Stocks.Where(s => s.StockName == inventoryView.StockName).Select(s => s.Id).FirstOrDefault();
                var WarehouseId = _context.Warehouses.Where(w => w.Location == inventoryView.Location).Select(w => w.Id).FirstOrDefault();

                Inventory addinventory = new Inventory()
                {
                    DateRecieved = inventoryView.DateRecieved,
                    EmployeeId = EmployeeId,
                    StockId = StockId,
                    Units = inventoryView.Unit,
                    WarehouseId = WarehouseId
                    
                };
                _context.Add(addinventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Employee"] = new SelectList(_context.Employees, "Name", "Name", inventoryView.Employee);
            ViewData["StockName"] = new SelectList(_context.Stocks, "StockName", "StockName", inventoryView.StockName);
            ViewData["Location"] = new SelectList(_context.Warehouses, "Location", "Location", inventoryView.Location);

            return View(inventoryView);
        }



        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", inventory.EmployeeId);
            ViewData["StockId"] = new SelectList(_context.Stocks, "Id", "Id", inventory.StockId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Id", inventory.WarehouseId);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateRecieved,StockId,WarehouseId,EmployeeId")] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", inventory.EmployeeId);
            ViewData["StockId"] = new SelectList(_context.Stocks, "Id", "Id", inventory.StockId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "Id", "Id", inventory.WarehouseId);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventories
                .Include(i => i.Employee)
                .Include(i => i.Stock)
                .Include(i => i.Warehouse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }
    }
}
