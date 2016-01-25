using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using StefanRiciu.Models;

namespace StefanRiciu.Controllers
{
    public class PaginiController : Controller
    {
        private ApplicationDbContext _context;

        public PaginiController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Pagini
        public IActionResult Index()
        {
            return View(_context.Pagina.ToList());
        }

        // GET: Pagini/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Pagina pagina = _context.Pagina.Single(m => m.PaginaID == id);
            if (pagina == null)
            {
                return HttpNotFound();
            }

            return View(pagina);
        }

        // GET: Pagini/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagini/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pagina pagina)
        {
            if (ModelState.IsValid)
            {
                _context.Pagina.Add(pagina);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagina);
        }

        // GET: Pagini/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Pagina pagina = _context.Pagina.Single(m => m.PaginaID == id);
            if (pagina == null)
            {
                return HttpNotFound();
            }
            return View(pagina);
        }

        // POST: Pagini/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pagina pagina)
        {
            if (ModelState.IsValid)
            {
                _context.Update(pagina);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagina);
        }

        // GET: Pagini/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Pagina pagina = _context.Pagina.Single(m => m.PaginaID == id);
            if (pagina == null)
            {
                return HttpNotFound();
            }

            return View(pagina);
        }

        // POST: Pagini/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Pagina pagina = _context.Pagina.Single(m => m.PaginaID == id);
            _context.Pagina.Remove(pagina);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
