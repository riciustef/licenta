using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using StefanRiciu.Models;
using Microsoft.AspNet.Authorization;
using System;

namespace StefanRiciu.Controllers
{
    //[RequireHttps]
    [Authorize]
    public class SponsoriController : Controller
    {
        private ApplicationDbContext _context;

        public SponsoriController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Sponsori
        public IActionResult Index()
        {
            var applicationDbContext = _context.Sponsor.Include(s => s.SponsorType);
            return View(applicationDbContext.ToList());
        }

        // GET: Sponsori/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sponsor sponsor = _context.Sponsor.Single(m => m.SponsorID == id);
            PopulareSponsorTypesDropDownList();
            if (sponsor == null)
            {
                return HttpNotFound();
            }

            return View(sponsor);
        }

        // GET: Sponsori/Create
        public IActionResult Create()
        {
            //ViewData["SponsorTypeID"] = new SelectList(_context.Set<SponsorType>(), "SponsorTypeID", "SponsorType");
            PopulareSponsorTypesDropDownList();
            return View();
        }

        // POST: Sponsori/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                sponsor.DataInregistrare = DateTime.Now;
                _context.Sponsor.Add(sponsor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["SponsorTypeID"] = new SelectList(_context.Set<SponsorType>(), "SponsorTypeID", "SponsorType", sponsor.SponsorTypeID);
            return View(sponsor);
        }

        // GET: Sponsori/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sponsor sponsor = _context.Sponsor.Single(m => m.SponsorID == id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            ViewData["SponsorTypeID"] = new SelectList(_context.Set<SponsorType>(), "SponsorTypeID", "SponsorType", sponsor.SponsorTypeID);
            PopulareSponsorTypesDropDownList();
            return View(sponsor);
        }

        // POST: Sponsori/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(sponsor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["SponsorTypeID"] = new SelectList(_context.Set<SponsorType>(), "SponsorTypeID", "SponsorType", sponsor.SponsorTypeID);
            return View(sponsor);
        }

        // GET: Sponsori/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Sponsor sponsor = _context.Sponsor.Single(m => m.SponsorID == id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }

            return View(sponsor);
        }

        // POST: Sponsori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Sponsor sponsor = _context.Sponsor.Single(m => m.SponsorID == id);
            _context.Sponsor.Remove(sponsor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // populare dropdown list trasee
        private void PopulareSponsorTypesDropDownList(object selectedSponsorType = null)
        {
            var sponsorTypeQuery = from st in _context.SponsorType
                              orderby st.Nume
                              select st;
            ViewData["SponsorTypeID"] = new SelectList(sponsorTypeQuery, "SponsorTypeID", "Nume", selectedSponsorType);
        }
    }
}
