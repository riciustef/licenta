using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using StefanRiciu.Models;

namespace StefanRiciu.Controllers
{
    public class SportiviController : Controller
    {
        private ApplicationDbContext _context;

        public SportiviController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Sportivi
        public IActionResult Index()
        {
            var applicationDbContext = _context.Sportiv.Include(s => s.Categorie).Include(s => s.Traseu);
            return View(applicationDbContext.ToList());
        }

        // GET: Sportivi/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sportiv sportiv = _context.Sportiv.Single(m => m.SportivID == id);
            if (sportiv == null)
            {
                return HttpNotFound();
            }

            return View(sportiv);
        }

        // GET: Sportivi/Create
        public IActionResult Create()
        {
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "Categorie");
            ViewData["TraseuID"] = new SelectList(_context.Traseu, "TraseuID", "Traseu");
            return View();
        }

        // POST: Sportivi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sportiv sportiv)
        {
            if (ModelState.IsValid)
            {
                _context.Sportiv.Add(sportiv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "Categorie", sportiv.CategorieID);
            ViewData["TraseuID"] = new SelectList(_context.Traseu, "TraseuID", "Traseu", sportiv.TraseuID);
            return View(sportiv);
        }

        // GET: Sportivi/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sportiv sportiv = _context.Sportiv.Single(m => m.SportivID == id);
            if (sportiv == null)
            {
                return HttpNotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "Categorie", sportiv.CategorieID);
            ViewData["TraseuID"] = new SelectList(_context.Traseu, "TraseuID", "Traseu", sportiv.TraseuID);
            return View(sportiv);
        }

        // POST: Sportivi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sportiv sportiv)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sportiv);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "Categorie", sportiv.CategorieID);
            ViewData["TraseuID"] = new SelectList(_context.Traseu, "TraseuID", "Traseu", sportiv.TraseuID);
            return View(sportiv);
        }

        // GET: Sportivi/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sportiv sportiv = _context.Sportiv.Single(m => m.SportivID == id);
            if (sportiv == null)
            {
                return HttpNotFound();
            }

            return View(sportiv);
        }

        // POST: Sportivi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Sportiv sportiv = _context.Sportiv.Single(m => m.SportivID == id);
            _context.Sportiv.Remove(sportiv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
