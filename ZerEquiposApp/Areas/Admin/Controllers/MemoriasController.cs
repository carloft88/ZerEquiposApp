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
    public class MemoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Memorias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Memoria.ToListAsync());
        }

        // GET: Admin/Memorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Memoria == null)
            {
                return NotFound();
            }

            var memorias = await _context.Memoria
                .FirstOrDefaultAsync(m => m.memoriaId == id);
            if (memorias == null)
            {
                return NotFound();
            }

            return View(memorias);
        }

        // GET: Admin/Memorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Memorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("memoriaId,NOmbre")] Memorias memorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memorias);
        }

        // GET: Admin/Memorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Memoria == null)
            {
                return NotFound();
            }

            var memorias = await _context.Memoria.FindAsync(id);
            if (memorias == null)
            {
                return NotFound();
            }
            return View(memorias);
        }

        // POST: Admin/Memorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("memoriaId,NOmbre")] Memorias memorias)
        {
            if (id != memorias.memoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoriasExists(memorias.memoriaId))
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
            return View(memorias);
        }

        // GET: Admin/Memorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Memoria == null)
            {
                return NotFound();
            }

            var memorias = await _context.Memoria
                .FirstOrDefaultAsync(m => m.memoriaId == id);
            if (memorias == null)
            {
                return NotFound();
            }

            return View(memorias);
        }

        // POST: Admin/Memorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Memoria == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Memoria'  is null.");
            }
            var memorias = await _context.Memoria.FindAsync(id);
            if (memorias != null)
            {
                _context.Memoria.Remove(memorias);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemoriasExists(int id)
        {
          return _context.Memoria.Any(e => e.memoriaId == id);
        }
    }
}
