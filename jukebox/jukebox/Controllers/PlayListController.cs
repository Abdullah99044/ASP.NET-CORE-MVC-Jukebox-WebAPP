using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return View();
            
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

        public IActionResult AddToPlayList()
        {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToPlayList(PlayLists obj)
        {


            _db.PlayLists.Add(obj);

            _db.SaveChanges();

            return RedirectToAction("MyPlayList");

        }
    }
}
