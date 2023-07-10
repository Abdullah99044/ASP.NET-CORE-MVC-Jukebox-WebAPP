using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace jukebox.Controllers
{
    public class PlayListController : Controller
    {



        private readonly ApplicationDbContext _db;

        public PlayListController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        public IActionResult MyPlayList()
        {

            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("/Identity/Account/Login");
            }

            var Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            IEnumerable<PlayLists> objPlaylists = _db.PlayLists.Where(s => s.UserId == Id).ToList();

            


            return View(objPlaylists);

        }


        //Post delete the play list
        public IActionResult DeletPlaylist() { 
        
            return View();
        
        }


        //Post remove a song from a play list
        public IActionResult DeletFromPlaylist()
        {

            return View();

        }


        //Post add a song to a play list


        public class twoModels
        {
            public PlayLists PlayLists { get; set; }
            public string userid { get; set; }
        }


        [HttpGet]
        public IActionResult AddToPlayList()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;


            var models = new twoModels
            {
                PlayLists = new PlayLists() ,

                userid = id


            };
                
                
            return View(models);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToPlayList(twoModels models )
        {


            _db.PlayLists.Add(models.PlayLists);

            _db.SaveChanges();

            return RedirectToAction("MyPlayList");

        }
    }
}
