using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Frameworks_ThatSneakerShop.Data;
using Frameworks_ThatSneakerShop.Models;

namespace Frameworks_ThatSneakerShop.Controllers
{
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Shoe.Include(w => w.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Shoe == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .FirstOrDefaultAsync(m => m.ShoeId == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoes/Create
        public IActionResult Create() {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoeId,CategoryId")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", shoe.CategoryId);
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Whislist == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", shoe.CategoryId);

            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoeId, CategoryId")] Shoe shoe)
        {
            if (id != shoe.ShoeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeExists(shoe.ShoeId))
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
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", shoe.CategoryId);
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Shoe == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .Include(w => w.Category)
                .FirstOrDefaultAsync(m => m.ShoeId == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Shoe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Shoe'  is null.");
            }
            var shoe = await _context.Shoe.FindAsync(id);
            if (shoe != null)
            {
                _context.Shoe.Remove(shoe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeExists(int id)
        {
          return _context.Shoe.Any(e => e.ShoeId == id);
        }
    }
}
