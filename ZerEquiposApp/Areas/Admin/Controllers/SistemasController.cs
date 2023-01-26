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
    public class SistemasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SistemasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Sistemas
        public async Task<IActionResult> Index()
        {
              return View(await _context.SO.ToListAsync());
        }

        // GET: Admin/Sistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SO == null)
            {
                return NotFound();
            }

            var sO = await _context.SO
                .FirstOrDefaultAsync(m => m.SoId == id);
            if (sO == null)
            {
                return NotFound();
            }

            return View(sO);
        }

        // GET: Admin/Sistemas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sistemas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoId,Nombre")] SO sO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sO);
        }

        // GET: Admin/Sistemas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SO == null)
            {
                return NotFound();
            }

            var sO = await _context.SO.FindAsync(id);
            if (sO == null)
            {
                return NotFound();
            }
            return View(sO);
        }

        // POST: Admin/Sistemas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoId,Nombre")] SO sO)
        {
            if (id != sO.SoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SOExists(sO.SoId))
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
            return View(sO);
        }

        // GET: Admin/Sistemas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SO == null)
            {
                return NotFound();
            }

            var sO = await _context.SO
                .FirstOrDefaultAsync(m => m.SoId == id);
            if (sO == null)
            {
                return NotFound();
            }

            return View(sO);
        }

        // POST: Admin/Sistemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SO == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SO'  is null.");
            }
            var sO = await _context.SO.FindAsync(id);
            if (sO != null)
            {
                _context.SO.Remove(sO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SOExists(int id)
        {
          return _context.SO.Any(e => e.SoId == id);
        }
    }
}
