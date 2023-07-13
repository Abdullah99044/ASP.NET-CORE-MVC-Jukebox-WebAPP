using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
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

        //PlayList page

        public class models_for_playlistPage
        {
            public string name { get; set; }

            public int id { get; set; }

            public IEnumerable<Saved_Songs> Saved { get; set; } 


        }

        [HttpGet]
        public IActionResult PlaylistPage(int id , string name)
        {

            IEnumerable<Saved_Songs> Saved_songs = _db.Saved_Songs.Include(s => s.Songs).Where(s => s.PlaylistId == id).ToList();

            var model = new models_for_playlistPage
            {

                name = name ,

                id = id ,

                Saved = Saved_songs

            };

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteFromPlaylist( int id , string name , int playlistid)
        {

            var row = _db.Saved_Songs.Find(id);
             

            _db.Saved_Songs.Remove(row);
            _db.SaveChanges();


            return RedirectToAction("PlaylistPage" , new { id = playlistid });
        }
    }
}
