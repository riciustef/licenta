using System.Linq;
using Microsoft.AspNet.Mvc;
using StefanRiciu.Models;
using Microsoft.AspNet.Authorization;

namespace StefanRiciu.Controllers
{
    //[RequireHttps]
    [Authorize]
    public class CategoriiController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriiController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Categorii
        public IActionResult Index()
        {
            return View(_context.Categorie.ToList());
        }

        // GET: Categorii/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Categorie categorie = _context.Categorie.Single(m => m.CategorieID == id);
            if (categorie == null)
            {
                return HttpNotFound();
            }

            return View(categorie);
        }

        // GET: Categorii/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorii/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Categorie.Add(categorie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categorii/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Categorie categorie = _context.Categorie.Single(m => m.CategorieID == id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Categorii/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Update(categorie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categorii/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Categorie categorie = _context.Categorie.Single(m => m.CategorieID == id);
            if (categorie == null)
            {
                return HttpNotFound();
            }

            return View(categorie);
        }

        // POST: Categorii/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Categorie categorie = _context.Categorie.Single(m => m.CategorieID == id);
            _context.Categorie.Remove(categorie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
