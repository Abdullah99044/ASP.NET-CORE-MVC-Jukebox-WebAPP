using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace jukebox.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db )
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Genres> objGeneres = _db.Genres;
            return View(objGeneres);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}