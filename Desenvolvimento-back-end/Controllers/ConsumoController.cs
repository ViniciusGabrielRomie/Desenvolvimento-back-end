using System.Threading.Tasks;
using Desenvolvimento_back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Desenvolvimento_back_end.Controllers
{
    public class ConsumoController : Controller

    {
        private readonly AppDbContext _context;
        public ConsumoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Consumos.Include(c => c.Veiculo).ToListAsync();
            return View(dados);
        }

        public async Task<IActionResult> Create()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(Combustivel)));
            ViewBag.Veiculos = new SelectList(veiculos, "Id", "Nome");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Consumos.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var veiculos =await _context.Veiculos.ToListAsync();
            if(id == null)
            {
                return NotFound();
            }
            var dados = await _context.Consumos.FindAsync(id);
            if(dados == null)
            {
                return NotFound();
            }
            ViewBag.Tipos = new SelectList(Enum.GetValues(typeof(Combustivel)));
            ViewBag.Veiculos = new SelectList(veiculos, "Id", "Nome");
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Consumo consumo)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.Consumos.FindAsync(id);
            if (dados == null)
            {
                return NotFound();
            }
             _context.Consumos.Update(dados);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
