using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Livraria.Data;
using Livraria.Models;

namespace Livraria.Controllers
{
    public class AssuntoController : Controller
    {
        private readonly AppDbContext _context;

        public AssuntoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Assunto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Assunto.ToListAsync());
        }

        // GET: Assunto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assunto
                .FirstOrDefaultAsync(m => m.CodAs == id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // GET: Assunto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assunto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodAs,Descricao")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assunto);
        }

        // GET: Assunto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assunto.FindAsync(id);
            if (assunto == null)
            {
                return NotFound();
            }
            return View(assunto);
        }

        // POST: Assunto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodAs,Descricao")] Assunto assunto)
        {
            if (id != assunto.CodAs)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssuntoExists(assunto.CodAs))
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
            return View(assunto);
        }

        // GET: Assunto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assunto
                .FirstOrDefaultAsync(m => m.CodAs == id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // POST: Assunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assunto = await _context.Assunto.FindAsync(id);
            if (assunto != null)
            {
                _context.Assunto.Remove(assunto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssuntoExists(int id)
        {
            return _context.Assunto.Any(e => e.CodAs == id);
        }
    }
}
