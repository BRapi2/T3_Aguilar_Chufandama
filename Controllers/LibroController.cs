using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using T3_Aguilar_Chufandama.Data;
using T3_Aguilar_Chufandama.Models;

namespace T3_Aguilar_Chufandama.Controllers
{
    [Authorize(Policy = "RequireAuthenticatedUser")]
    public class LibroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Libro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libros.ToListAsync());
        }

        // GET: Libro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var libro = await _context.Libros.FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
                return NotFound();

            return View(libro);
        }

        // GET: Libro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Tema,Editorial,AnioPublicacion,Paginas,Categoria,Material,Copias")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
                return NotFound();

            return View(libro);
        }

        // POST: Libro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Autor,Tema,Editorial,AnioPublicacion,Paginas,Categoria,Material,Copias")] Libro libro)
        {
            if (id != libro.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }

        // GET: Libro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var libro = await _context.Libros.FirstOrDefaultAsync(m => m.Id == id);
            if (libro == null)
                return NotFound();

            return View(libro);
        }

        // POST: Libro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
