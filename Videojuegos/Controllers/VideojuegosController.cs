using Microsoft.AspNetCore.Mvc;
using Videojuegos.Data;
using Videojuegos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Videojuegos.Controllers
{
    public class VideojuegosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideojuegosController(ApplicationDbContext context)
        {
            _context = context;
        }
        private void CargarGeneros(string generoSeleccionado = null)
        {
            var generos = new List<string>
            {
                "Acción",
                "Aventura",
                "RPG",
                "Shooter",
                "Deportes",
                "Estrategia"
            };

            ViewBag.Generos = new SelectList(generos, generoSeleccionado);
        }

        // GET: Listado
        public IActionResult Index()
        {
            var videojuegos = _context.Videojuegos.ToList();
            if (videojuegos == null)
                videojuegos = new List<Videojuego>();

            return View(videojuegos);
        }

        // GET: Detalles
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var videojuego = await _context.Videojuegos.FirstOrDefaultAsync(m => m.Id == id);
            if (videojuego == null) return NotFound();

            return View(videojuego);
        }

        // GET: Crear
        public IActionResult Create()
        {
            CargarGeneros();
            return View();
        }

        // POST: Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videojuego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CargarGeneros(videojuego.Genre);
            return View(videojuego);
        }

        // GET: Editar
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var videojuego = await _context.Videojuegos.FindAsync(id);
            if (videojuego == null) return NotFound();

            CargarGeneros(videojuego.Genre);
            return View(videojuego);
        }

        // POST: Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Videojuego videojuego)
        {
            if (id != videojuego.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(videojuego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CargarGeneros(videojuego.Genre);
            return View(videojuego);
        }

        // GET: Eliminar
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var videojuego = await _context.Videojuegos.FirstOrDefaultAsync(m => m.Id == id);
            if (videojuego == null) return NotFound();

            return View(videojuego);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videojuego = await _context.Videojuegos.FindAsync(id);
            _context.Videojuegos.Remove(videojuego);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
