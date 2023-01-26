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
    public class EmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Empleados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empleado.Include(e => e.Cargo).Include(e => e.Empresa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.Cargo)
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(m => m.empleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Admin/Empleados/Create
        public IActionResult Create()
        {
            ViewData["cargoID"] = new SelectList(_context.Cargo, "cargoID", "Nombre");
            ViewData["empresaID"] = new SelectList(_context.Empresa, "empresaId", "NOmbre");
            return View();
        }

        // POST: Admin/Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empleadoID,Nombre,cedula,FechaIngreso,empresaID,cargoID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cargoID"] = new SelectList(_context.Cargo, "cargoID", "Nombre", empleado.cargoID);
            ViewData["empresaID"] = new SelectList(_context.Empresa, "empresaId", "NOmbre", empleado.empresaID);
            return View(empleado);
        }

        // GET: Admin/Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["cargoID"] = new SelectList(_context.Cargo, "cargoID", "Nombre", empleado.cargoID);
            ViewData["empresaID"] = new SelectList(_context.Empresa, "empresaId", "NOmbre", empleado.empresaID);
            return View(empleado);
        }

        // POST: Admin/Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empleadoID,Nombre,cedula,FechaIngreso,empresaID,cargoID")] Empleado empleado)
        {
            if (id != empleado.empleadoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.empleadoID))
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
            ViewData["cargoID"] = new SelectList(_context.Cargo, "cargoID", "Nombre", empleado.cargoID);
            ViewData["empresaID"] = new SelectList(_context.Empresa, "empresaId", "NOmbre", empleado.empresaID);
            return View(empleado);
        }

        // GET: Admin/Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.Cargo)
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(m => m.empleadoID == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Admin/Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleado == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Empleado'  is null.");
            }
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return _context.Empleado.Any(e => e.empleadoID == id);
        }
    }
}
