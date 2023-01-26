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
    public class EquipoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Equipoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Equipo.Include(e => e.Canon).Include(e => e.Categoria).Include(e => e.Empleado).Include(e => e.Fabricante).Include(e => e.Memoria).Include(e => e.Procesador).Include(e => e.Sistema).Include(e => e.licenciamiento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Equipoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.Canon)
                .Include(e => e.Categoria)
                .Include(e => e.Empleado)
                .Include(e => e.Fabricante)
                .Include(e => e.Memoria)
                .Include(e => e.Procesador)
                .Include(e => e.Sistema)
                .Include(e => e.licenciamiento)
                .FirstOrDefaultAsync(m => m.equipoID == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // GET: Admin/Equipoes/Create
        public IActionResult Create()
        {
            ViewData["CanonId"] = new SelectList(_context.Canon, "CanonId", "Nombre");
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre");
            ViewData["empleadoID"] = new SelectList(_context.Empleado, "empleadoID", "Nombre");
            ViewData["FabricanteId"] = new SelectList(_context.Set<Fabricante>(), "FrabricanteId", "Nombre");
            ViewData["memoriaId"] = new SelectList(_context.Memoria, "memoriaId", "NOmbre");
            ViewData["procesadorId"] = new SelectList(_context.Procesador, "procesadorId", "Nombre");
            ViewData["SoId"] = new SelectList(_context.SO, "SoId", "Nombre");
            ViewData["licenciamientoId"] = new SelectList(_context.Licenciamiento, "licenciamientoId", "Nombre");
            return View();
        }

        // POST: Admin/Equipoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("equipoID,Nombre,CategoriaId,FechaCompra,Fecha_fabrica,SoId,memoriaId,procesadorId,empleadoID,Estado,Modelo,Precio,activoFijo,serial,Observaciones,licenciamientoId,FabricanteId,CanonId")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CanonId"] = new SelectList(_context.Canon, "CanonId", "Nombre", equipo.CanonId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre", equipo.CategoriaId);
            ViewData["empleadoID"] = new SelectList(_context.Empleado, "empleadoID", "Nombre", equipo.empleadoID);
            ViewData["FabricanteId"] = new SelectList(_context.Set<Fabricante>(), "FrabricanteId", "Nombre", equipo.FabricanteId);
            ViewData["memoriaId"] = new SelectList(_context.Memoria, "memoriaId", "NOmbre", equipo.memoriaId);
            ViewData["procesadorId"] = new SelectList(_context.Procesador, "procesadorId", "Nombre", equipo.procesadorId);
            ViewData["SoId"] = new SelectList(_context.SO, "SoId", "Nombre", equipo.SoId);
            ViewData["licenciamientoId"] = new SelectList(_context.Licenciamiento, "licenciamientoId", "Nombre", equipo.licenciamientoId);
            return View(equipo);
        }

        // GET: Admin/Equipoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }
            ViewData["CanonId"] = new SelectList(_context.Canon, "CanonId", "Nombre", equipo.CanonId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre", equipo.CategoriaId);
            ViewData["empleadoID"] = new SelectList(_context.Empleado, "empleadoID", "Nombre", equipo.empleadoID);
            ViewData["FabricanteId"] = new SelectList(_context.Set<Fabricante>(), "FrabricanteId", "Nombre", equipo.FabricanteId);
            ViewData["memoriaId"] = new SelectList(_context.Memoria, "memoriaId", "NOmbre", equipo.memoriaId);
            ViewData["procesadorId"] = new SelectList(_context.Procesador, "procesadorId", "Nombre", equipo.procesadorId);
            ViewData["SoId"] = new SelectList(_context.SO, "SoId", "Nombre", equipo.SoId);
            ViewData["licenciamientoId"] = new SelectList(_context.Licenciamiento, "licenciamientoId", "Nombre", equipo.licenciamientoId);
            return View(equipo);
        }

        // POST: Admin/Equipoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("equipoID,Nombre,CategoriaId,FechaCompra,Fecha_fabrica,SoId,memoriaId,procesadorId,empleadoID,Estado,Modelo,Precio,activoFijo,serial,Observaciones,licenciamientoId,FabricanteId,CanonId")] Equipo equipo)
        {
            if (id != equipo.equipoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoExists(equipo.equipoID))
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
            ViewData["CanonId"] = new SelectList(_context.Canon, "CanonId", "Nombre", equipo.CanonId);
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "Nombre", equipo.CategoriaId);
            ViewData["empleadoID"] = new SelectList(_context.Empleado, "empleadoID", "Nombre", equipo.empleadoID);
            ViewData["FabricanteId"] = new SelectList(_context.Set<Fabricante>(), "FrabricanteId", "Nombre", equipo.FabricanteId);
            ViewData["memoriaId"] = new SelectList(_context.Memoria, "memoriaId", "NOmbre", equipo.memoriaId);
            ViewData["procesadorId"] = new SelectList(_context.Procesador, "procesadorId", "Nombre", equipo.procesadorId);
            ViewData["SoId"] = new SelectList(_context.SO, "SoId", "Nombre", equipo.SoId);
            ViewData["licenciamientoId"] = new SelectList(_context.Licenciamiento, "licenciamientoId", "Nombre", equipo.licenciamientoId);
            return View(equipo);
        }

        // GET: Admin/Equipoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipo == null)
            {
                return NotFound();
            }

            var equipo = await _context.Equipo
                .Include(e => e.Canon)
                .Include(e => e.Categoria)
                .Include(e => e.Empleado)
                .Include(e => e.Fabricante)
                .Include(e => e.Memoria)
                .Include(e => e.Procesador)
                .Include(e => e.Sistema)
                .Include(e => e.licenciamiento)
                .FirstOrDefaultAsync(m => m.equipoID == id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }

        // POST: Admin/Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Equipo'  is null.");
            }
            var equipo = await _context.Equipo.FindAsync(id);
            if (equipo != null)
            {
                _context.Equipo.Remove(equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoExists(int id)
        {
          return _context.Equipo.Any(e => e.equipoID == id);
        }
    }
}
