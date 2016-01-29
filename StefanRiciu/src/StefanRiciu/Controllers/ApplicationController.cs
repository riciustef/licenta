using System.Linq;
using Microsoft.AspNet.Mvc;
using StefanRiciu.Models;

namespace StefanRiciu.Controllers
{
    //[RequireHttps]
    public abstract class ApplicationController : Controller
    {
        private ApplicationDbContext _context;

        public ApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationController()
        {
            ViewData["organizatori"] = from s in _context.Sponsor
                                   select s;
        }
    }
}
