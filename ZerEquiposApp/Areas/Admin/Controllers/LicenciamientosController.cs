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
    public class LicenciamientosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LicenciamientosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Licenciamientos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Licenciamiento.ToListAsync());
        }

        // GET: Admin/Licenciamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Licenciamiento == null)
            {
                return NotFound();
            }

            var licenciamiento = await _context.Licenciamiento
                .FirstOrDefaultAsync(m => m.licenciamientoId == id);
            if (licenciamiento == null)
            {
                return NotFound();
            }

            return View(licenciamiento);
        }

        // GET: Admin/Licenciamientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Licenciamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("licenciamientoId,Nombre")] Licenciamiento licenciamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(licenciamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(licenciamiento);
        }

        // GET: Admin/Licenciamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Licenciamiento == null)
            {
                return NotFound();
            }

            var licenciamiento = await _context.Licenciamiento.FindAsync(id);
            if (licenciamiento == null)
            {
                return NotFound();
            }
            return View(licenciamiento);
        }

        // POST: Admin/Licenciamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("licenciamientoId,Nombre")] Licenciamiento licenciamiento)
        {
            if (id != licenciamiento.licenciamientoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenciamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenciamientoExists(licenciamiento.licenciamientoId))
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
            return View(licenciamiento);
        }

        // GET: Admin/Licenciamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Licenciamiento == null)
            {
                return NotFound();
            }

            var licenciamiento = await _context.Licenciamiento
                .FirstOrDefaultAsync(m => m.licenciamientoId == id);
            if (licenciamiento == null)
            {
                return NotFound();
            }

            return View(licenciamiento);
        }

        // POST: Admin/Licenciamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Licenciamiento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Licenciamiento'  is null.");
            }
            var licenciamiento = await _context.Licenciamiento.FindAsync(id);
            if (licenciamiento != null)
            {
                _context.Licenciamiento.Remove(licenciamiento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LicenciamientoExists(int id)
        {
          return _context.Licenciamiento.Any(e => e.licenciamientoId == id);
        }
    }
}
