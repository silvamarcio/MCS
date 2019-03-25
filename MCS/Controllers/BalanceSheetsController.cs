using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MCS.Models;

namespace MCS.Controllers
{
    public class BalanceSheetsController : Controller
    {
        private readonly MCSContext _context;

        public BalanceSheetsController(MCSContext context)
        {
            _context = context;
        }

        // GET: BalanceSheets
        public async Task<IActionResult> Index()
        {
            var mCSContext = _context.BalanceSheet.Include(b => b.Employee);
            return View(await mCSContext.ToListAsync());
        }

        // GET: BalanceSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balanceSheet = await _context.BalanceSheet
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanceSheet == null)
            {
                return NotFound();
            }

            return View(balanceSheet);
        }

        //GET: BalanceSheet/BalanceInOut/5
        public async Task<IActionResult> BalanceInOut(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var balanceSheets = await _context.BalanceSheet
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanceSheets == null)
            {
                return NotFound();
            }
           
            return View(balanceSheets);
        }

        // GET: BalanceSheets/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: BalanceSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Balance,EmployeeId")] BalanceSheet balanceSheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(balanceSheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", balanceSheet.EmployeeId);
            return View(balanceSheet);
        }

        // GET: BalanceSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balanceSheet = await _context.BalanceSheet.FindAsync(id);
            if (balanceSheet == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", balanceSheet.EmployeeId);
            return View(balanceSheet);
        }

        // POST: BalanceSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Balance,EmployeeId")] BalanceSheet balanceSheet)
        {
            if (id != balanceSheet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(balanceSheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceSheetExists(balanceSheet.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", balanceSheet.EmployeeId);
            return View(balanceSheet);
        }

        // GET: BalanceSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balanceSheet = await _context.BalanceSheet
                .Include(b => b.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (balanceSheet == null)
            {
                return NotFound();
            }

            return View(balanceSheet);
        }

        // POST: BalanceSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var balanceSheet = await _context.BalanceSheet.FindAsync(id);
            _context.BalanceSheet.Remove(balanceSheet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceSheetExists(int id)
        {
            return _context.BalanceSheet.Any(e => e.Id == id);
        }

        
    }
}
