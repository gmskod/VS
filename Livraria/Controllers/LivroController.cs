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
    public class LivroController : Controller
    {
        private readonly AppDbContext _context;

        public LivroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Livro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Livro.ToListAsync());
        }

        // GET: Livro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Codl == id);
            if (Livro == null)
            {
                return NotFound();
            }

            return View(Livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            // Populando os selects de autores e assuntos
            ViewBag.Autores = _context.Autor.ToList();
            ViewBag.Assuntos = _context.Assunto.ToList();

            return View();
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro, List<int> autoresIds, List<int> assuntosIds)
        {
            if (ModelState.IsValid)
            {
                _context.Livro.Add(livro);
                await _context.SaveChangesAsync(); // Salva o livro e gera o ID

                // Adicionar os registros nas tabelas de relacionamento
                if (autoresIds != null && autoresIds.Count > 0)
                {
                    foreach (var autorId in autoresIds)
                    {
                        _context.Livro_Autor.Add(new LivroAutor { Livro_Codl = livro.Codl, Autor_CodAu = autorId });
                    }
                }

                if (assuntosIds != null && assuntosIds.Count > 0)
                {
                    foreach (var assuntoId in assuntosIds)
                    {
                        _context.Livro_Assunto.Add(new LivroAssunto { Livro_Codl = livro.Codl, Assunto_CodAs = assuntoId });
                    }
                }

                await _context.SaveChangesAsync(); // Salva os relacionamentos

                return RedirectToAction(nameof(Index));
            }

            // Caso algo dê errado, retorna a view com os dados
            ViewBag.Autores = _context.Autor.ToList();
            ViewBag.Assuntos = _context.Assunto.ToList();
            return View(livro);
        }

        // GET: Livro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Livro = await _context.Livro.FindAsync(id);
            if (Livro == null)
            {
                return NotFound();
            }
            return View(Livro);
        }

        // POST: Livro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codl,Nome")] Livro Livro)
        {
            if (id != Livro.Codl)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(Livro.Codl))
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
            return View(Livro);
        }

        // GET: Livro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Livro = await _context.Livro
                .FirstOrDefaultAsync(m => m.Codl == id);
            if (Livro == null)
            {
                return NotFound();
            }

            return View(Livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Livro = await _context.Livro.FindAsync(id);
            if (Livro != null)
            {
                _context.Livro.Remove(Livro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _context.Livro.Any(e => e.Codl == id);
        }
    }
}
