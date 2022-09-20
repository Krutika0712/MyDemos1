using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website.Data;
using Website.Models;

namespace Website.Areas.LoanMgmt.Controllers
{
    [Area("LoanMgmt")]
    public class LoanCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoanCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LoanMgmt/LoanCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LoanCategory.Include(l => l.Loan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LoanMgmt/LoanCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanCategory = await _context.LoanCategory
                .Include(l => l.Loan)
                .FirstOrDefaultAsync(m => m.LoanCategoryId == id);
            if (loanCategory == null)
            {
                return NotFound();
            }

            return View(loanCategory);
        }

        // GET: LoanMgmt/LoanCategories/Create
        public IActionResult Create()
        {
            ViewData["LoanId"] = new SelectList(_context.Loans, "LoanId", "LoanName");
            return View();
        }

        // POST: LoanMgmt/LoanCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanCategoryId,LoanCategoryName,Amount,Description,Eligibility,LoanId")] LoanCategory loanCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoanId"] = new SelectList(_context.Loans, "LoanId", "LoanName", loanCategory.LoanId);
            return View(loanCategory);
        }

        // GET: LoanMgmt/LoanCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanCategory = await _context.LoanCategory.FindAsync(id);
            if (loanCategory == null)
            {
                return NotFound();
            }
            ViewData["LoanId"] = new SelectList(_context.Loans, "LoanId", "LoanName", loanCategory.LoanId);
            return View(loanCategory);
        }

        // POST: LoanMgmt/LoanCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanCategoryId,LoanCategoryName,Amount,Description,Eligibility,LoanId")] LoanCategory loanCategory)
        {
            if (id != loanCategory.LoanCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanCategoryExists(loanCategory.LoanCategoryId))
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
            ViewData["LoanId"] = new SelectList(_context.Loans, "LoanId", "LoanName", loanCategory.LoanId);
            return View(loanCategory);
        }

        // GET: LoanMgmt/LoanCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanCategory = await _context.LoanCategory
                .Include(l => l.Loan)
                .FirstOrDefaultAsync(m => m.LoanCategoryId == id);
            if (loanCategory == null)
            {
                return NotFound();
            }

            return View(loanCategory);
        }

        // POST: LoanMgmt/LoanCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanCategory = await _context.LoanCategory.FindAsync(id);
            _context.LoanCategory.Remove(loanCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanCategoryExists(int id)
        {
            return _context.LoanCategory.Any(e => e.LoanCategoryId == id);
        }
    }
}
