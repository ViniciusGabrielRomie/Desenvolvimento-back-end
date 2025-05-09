using System.Threading.Tasks;
using Desenvolvimento_back_end.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desenvolvimento_back_end.Controllers
{
    [Authorize]
    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async  Task<IActionResult> Edit(int? id)
        {
            if(id  == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);
            if(dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculos)
        {
            if(id != veiculos.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);
            if(dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }
       
        public async Task<IActionResult> Deletar(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);
            if(dados == null)
            {
                return NotFound();
            }
            return View(dados);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var dados = await _context.Veiculos.FindAsync(id);
            if(dados == null)
            {
                return NotFound();
            }
            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();  
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Relatorio(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var veiculos = await _context.Veiculos.FindAsync(id);
            if(veiculos == null)
            {
                return NotFound();
            }
            var consumos = await _context.Consumos
                .Where(c => c.VeiculoId == id)
                .OrderByDescending(c => c.Data).
                ToListAsync();

            decimal total = consumos.Sum(c => c.Valor);

            ViewBag.Veiculo = veiculos;
            ViewBag.Total = total;

            return View(consumos);
        }
    }
}
