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
    public class WhislistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhislistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Whislists
        public async Task<IActionResult> Index(string searchField = "") {
            List<Whislist> lists = await _context.Whislist.
                                   Where(g => g.Shoe.ShoeName.Contains(searchField) || searchField != " ")
                                   .Include(g => g.Shoe).ToListAsync();
            ViewData["searchField"] = searchField;
            return View(lists);

            //var applicationDbContext = _context.Whislist.Include(w => w.Shoe);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Whislists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Whislist == null)
            {
                return NotFound();
            }

            var whislist = await _context.Whislist
                .Include(w => w.Shoe)
                .FirstOrDefaultAsync(m => m.WhislistId == id);
            if (whislist == null)
            {
                return NotFound();
            }

            return View(whislist);
        }

        // GET: Whislists/Create
        public IActionResult Create()
        {
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ShoeId", "ShoeDescription");
            return View();
        }

        // POST: Whislists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WhislistId,ShoeId")] Whislist whislist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whislist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ShoeId", "ShoeDescription", whislist.ShoeId);
            return View(whislist);
        }

        // GET: Whislists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Whislist == null)
            {
                return NotFound();
            }

            var whislist = await _context.Whislist.FindAsync(id);
            if (whislist == null)
            {
                return NotFound();
            }
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ShoeId", "ShoeDescription", whislist.ShoeId);
            return View(whislist);
        }

        // POST: Whislists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WhislistId,ShoeId")] Whislist whislist)
        {
            if (id != whislist.WhislistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whislist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhislistExists(whislist.WhislistId))
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
            ViewData["ShoeId"] = new SelectList(_context.Shoe, "ShoeId", "ShoeDescription", whislist.ShoeId);
            return View(whislist);
        }

        // GET: Whislists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Whislist == null)
            {
                return NotFound();
            }

            var whislist = await _context.Whislist
                .Include(w => w.Shoe)
                .FirstOrDefaultAsync(m => m.WhislistId == id);
            if (whislist == null)
            {
                return NotFound();
            }

            return View(whislist);
        }

        // POST: Whislists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Whislist == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Whislist'  is null.");
            }
            var whislist = await _context.Whislist.FindAsync(id);
            if (whislist != null)
            {
                _context.Whislist.Remove(whislist);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhislistExists(int id)
        {
          return _context.Whislist.Any(e => e.WhislistId == id);
        }
    }
}
