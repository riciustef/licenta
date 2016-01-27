using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using StefanRiciu.Models;

namespace StefanRiciu.Controllers
{
    [RequireHttps]
    public class SponsorTypesController : Controller
    {
        private ApplicationDbContext _context;

        public SponsorTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: SponsorTypes
        public IActionResult Index()
        {
            return View(_context.SponsorType.ToList());
        }

        // GET: SponsorTypes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SponsorType sponsorType = _context.SponsorType.Single(m => m.SponsorTypeID == id);
            if (sponsorType == null)
            {
                return HttpNotFound();
            }

            return View(sponsorType);
        }

        // GET: SponsorTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SponsorTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SponsorType sponsorType)
        {
            if (ModelState.IsValid)
            {
                _context.SponsorType.Add(sponsorType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsorType);
        }

        // GET: SponsorTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SponsorType sponsorType = _context.SponsorType.Single(m => m.SponsorTypeID == id);
            if (sponsorType == null)
            {
                return HttpNotFound();
            }
            return View(sponsorType);
        }

        // POST: SponsorTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SponsorType sponsorType)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sponsorType);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsorType);
        }

        // GET: SponsorTypes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            SponsorType sponsorType = _context.SponsorType.Single(m => m.SponsorTypeID == id);
            if (sponsorType == null)
            {
                return HttpNotFound();
            }

            return View(sponsorType);
        }

        // POST: SponsorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            SponsorType sponsorType = _context.SponsorType.Single(m => m.SponsorTypeID == id);
            _context.SponsorType.Remove(sponsorType);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
