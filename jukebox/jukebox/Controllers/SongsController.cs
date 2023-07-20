using jukebox.Data;
using jukebox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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



        //Add songs to a play list

        

        public class AddToPlayListModels
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public Saved_Songs Saved { get; set; }

            public IEnumerable<PlayLists> playLists { get; set; }

           
        }

        [HttpGet]
        public IActionResult AddToPlayListView(int id , string name)
        {
            if (User.Identity.IsAuthenticated) {

                string UserID = User.FindFirst(ClaimTypes.NameIdentifier).Value;


                bool userHasSongs = _db.PlayLists.Any(s => s.UserId == UserID);


                if (userHasSongs)
                {
                    IEnumerable<PlayLists> UserPlayLists = _db.PlayLists.Where(s => s.UserId == UserID).ToList();

                    var model = new AddToPlayListModels
                    {
                        Id = id,

                        Name = name,

                        Saved = new Saved_Songs(),

                        playLists = UserPlayLists


                    };

                    return View(model);

                }

                else
                {


                    TempData["NoPlayList"] = "You dont have any Play lists , so please make a play list ";
                    return View();
                }

                

            }

            return RedirectToAction("/Identity/Account/Login");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToPlayList(AddToPlayListModels obj)
        {

            _db.Saved_Songs.Add(obj.Saved);
            _db.SaveChanges();

            return RedirectToAction("Index" , "Genre");
        }
    }
}
