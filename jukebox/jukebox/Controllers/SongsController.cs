using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jukebox.Controllers
{
    public class SongsController : Controller
    {


        private readonly ApplicationDbContext _db;

        public SongsController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get
        public IActionResult Index(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Songs> songsGenre = _db.Songs.Where(s => s.Genres.Id == id).ToList();

            if (songsGenre == null)
            {
                return NotFound();
            }

            return View(songsGenre);
        }



        //Direct song to add to plylist page

        public IActionResult AddToPlayList(int id)
        {
            return View();
        }
    }
}
