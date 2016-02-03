using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Authorization;
using Microsoft.Data.Entity;
using System.Threading.Tasks;
using StefanRiciu.Models;
using StefanRiciu.Services;

namespace StefanRiciu.Controllers
{
    //[RequireHttps]
    [Authorize]
    public class SportiviController : Controller
    {
        private ApplicationDbContext _context;
        //private readonly IEmailSender _emailSender;

        public SportiviController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sportivi
        [AllowAnonymous]
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

            PopulareCategoriiDropDownList();
            PopulareTraseeDropDownList();

            if (sportiv == null)
            {
                return HttpNotFound();
            }

            return View(sportiv);
        }

        // GET: Sportivi/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            PopulareCategoriiDropDownList();
            PopulareTraseeDropDownList();

            return View();
        }

        // POST: Sportivi/Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sportiv sportiv)
        {
            if (ModelState.IsValid)
            {
                
                sportiv.DataInregistrare = DateTime.Now;
                _context.Sportiv.Add(sportiv);
                _context.SaveChanges();
                //var emailSubject = "Inscriere concurs";
                //var emailContent = "Va multumim pentru inscrierea la concurs.";
                // _emailSender.SendEmailAsync("riciustef@gmail.com", emailSubject, "Un nou concurent inscris la concurs.");
                //_emailSender.SendEmailAsync(sportiv.Email, emailSubject, emailContent);

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
            PopulareCategoriiDropDownList(sportiv.CategorieID);
            PopulareTraseeDropDownList(sportiv.TraseuID);
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

        // populare dropdown list categorii
        private void PopulareCategoriiDropDownList(object selectedCategorie = null)
        {
            var categoriiQuery = from c in _context.Categorie
                                 orderby c.Nume
                                 select c;
            ViewData["CategorieID"] = new SelectList(categoriiQuery, "CategorieID", "Nume", selectedCategorie);
        }

        // populare dropdown list trasee
        private void PopulareTraseeDropDownList(object selectedTraseu = null)
        {
            var traseuQuery = from t in _context.Traseu
                              orderby t.Denumire
                              select t;
            ViewData["TraseuID"] = new SelectList(traseuQuery, "TraseuID", "Denumire", selectedTraseu);
        }
    }
}
