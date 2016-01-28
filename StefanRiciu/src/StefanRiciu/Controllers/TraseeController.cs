using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using StefanRiciu.Models;
using Microsoft.AspNet.Authorization;

namespace StefanRiciu.Controllers
{
    [RequireHttps]
    [Authorize]
    public class TraseeController : Controller
    {
        private ApplicationDbContext _context;

        public TraseeController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Trasee
        public IActionResult Index()
        {
            return View(_context.Traseu.ToList());
        }

        // GET: Trasee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Traseu traseu = _context.Traseu.Single(m => m.TraseuID == id);
            if (traseu == null)
            {
                return HttpNotFound();
            }

            return View(traseu);
        }

        // GET: Trasee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trasee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Traseu traseu)
        {
            if (ModelState.IsValid)
            {
                _context.Traseu.Add(traseu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traseu);
        }

        // GET: Trasee/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Traseu traseu = _context.Traseu.Single(m => m.TraseuID == id);
            if (traseu == null)
            {
                return HttpNotFound();
            }
            return View(traseu);
        }

        // POST: Trasee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Traseu traseu)
        {
            if (ModelState.IsValid)
            {
                _context.Update(traseu);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traseu);
        }

        // GET: Trasee/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Traseu traseu = _context.Traseu.Single(m => m.TraseuID == id);
            if (traseu == null)
            {
                return HttpNotFound();
            }

            return View(traseu);
        }

        // POST: Trasee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Traseu traseu = _context.Traseu.Single(m => m.TraseuID == id);
            _context.Traseu.Remove(traseu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
