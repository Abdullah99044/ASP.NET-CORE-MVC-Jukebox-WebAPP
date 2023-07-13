using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jukebox.Controllers
{
    public class SongsDetailsController : Controller
    {



        private readonly ApplicationDbContext _db;

        public SongsDetailsController(ApplicationDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Index(int Id)
        {

            int SongID = Id;

            IEnumerable<Songs> obj =  _db.Songs.Include(a => a.Genres).Where(s => s.Id == SongID).ToList();


            return View(obj);
        }
    }
}
