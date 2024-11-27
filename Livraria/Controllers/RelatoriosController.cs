using Microsoft.AspNetCore.Mvc;
using Livraria.Models;
using Livraria.Data;
using System.Linq;

namespace Livraria.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Relatorio()
        {
            var relatorio = _context.RelatorioLivro.ToList(); // ou qualquer lógica para gerar o relatório
            return View(relatorio);
        }
    }
}