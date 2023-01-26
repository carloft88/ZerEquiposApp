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
    public class ProcesadorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProcesadorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Procesador
        public async Task<IActionResult> Index()
        {
              return View(await _context.Procesador.ToListAsync());
        }

        // GET: Admin/Procesador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Procesador == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador
                .FirstOrDefaultAsync(m => m.procesadorId == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // GET: Admin/Procesador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Procesador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("procesadorId,Nombre,Genracion")] Procesador procesador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesador);
        }

        // GET: Admin/Procesador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Procesador == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador.FindAsync(id);
            if (procesador == null)
            {
                return NotFound();
            }
            return View(procesador);
        }

        // POST: Admin/Procesador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("procesadorId,Nombre,Genracion")] Procesador procesador)
        {
            if (id != procesador.procesadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesadorExists(procesador.procesadorId))
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
            return View(procesador);
        }

        // GET: Admin/Procesador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Procesador == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador
                .FirstOrDefaultAsync(m => m.procesadorId == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // POST: Admin/Procesador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Procesador == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Procesador'  is null.");
            }
            var procesador = await _context.Procesador.FindAsync(id);
            if (procesador != null)
            {
                _context.Procesador.Remove(procesador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesadorExists(int id)
        {
          return _context.Procesador.Any(e => e.procesadorId == id);
        }
    }
}
