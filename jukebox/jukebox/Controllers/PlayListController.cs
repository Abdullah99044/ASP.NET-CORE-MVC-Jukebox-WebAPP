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

 
        //Create a play list


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

        //Update a play list


        [HttpGet]
        public IActionResult EditPlayListView(int id)
        {


            var obj = _db.PlayLists.Find(id);



            return View(obj);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPlayList(PlayLists obj)
        {


            _db.PlayLists.Update(obj);
            _db.SaveChanges();


            return RedirectToAction("MyPlayList");

        }

        //Delete the play list


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletPlaylist(int id)
        {


            var row = _db.PlayLists.Find(id);

            if (row == null)
            {
                return NotFound();
            }

            _db.PlayLists.Remove(row);
            _db.SaveChanges();

            return RedirectToAction("MyPlayList");

        }
    }
}
