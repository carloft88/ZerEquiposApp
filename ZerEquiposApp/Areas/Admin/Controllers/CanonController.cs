using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPP.Models;
using ZerEquiposApp.Data;

namespace ZerEquiposApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CanonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CanonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Canon
        public async Task<IActionResult> Index()
        {
              return View(await _context.Canon.ToListAsync());
        }

        // GET: Admin/Canon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Canon == null)
            {
                return NotFound();
            }

            var canon = await _context.Canon
                .FirstOrDefaultAsync(m => m.CanonId == id);
            if (canon == null)
            {
                return NotFound();
            }

            return View(canon);
        }

        // GET: Admin/Canon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Canon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CanonId,Nombre")] Canon canon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(canon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(canon);
        }

        // GET: Admin/Canon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Canon == null)
            {
                return NotFound();
            }

            var canon = await _context.Canon.FindAsync(id);
            if (canon == null)
            {
                return NotFound();
            }
            return View(canon);
        }

        // POST: Admin/Canon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CanonId,Nombre")] Canon canon)
        {
            if (id != canon.CanonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(canon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CanonExists(canon.CanonId))
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
            return View(canon);
        }

        // GET: Admin/Canon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Canon == null)
            {
                return NotFound();
            }

            var canon = await _context.Canon
                .FirstOrDefaultAsync(m => m.CanonId == id);
            if (canon == null)
            {
                return NotFound();
            }

            return View(canon);
        }

        // POST: Admin/Canon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Canon == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Canon'  is null.");
            }
            var canon = await _context.Canon.FindAsync(id);
            if (canon != null)
            {
                _context.Canon.Remove(canon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CanonExists(int id)
        {
          return _context.Canon.Any(e => e.CanonId == id);
        }
    }
}
