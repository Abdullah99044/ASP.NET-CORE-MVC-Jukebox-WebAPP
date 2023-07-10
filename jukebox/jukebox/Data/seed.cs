using jukebox.Models;

namespace jukebox.Data
{
    public class seed
    {

        public static void seeding(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var db = servicescope.ServiceProvider.GetService<ApplicationDbContext>();


                //Genres 

                if (!db.Genres.Any())
                {

                    db.Genres.AddRange(new List<Genres>()
                    {

                        new Genres()
                        {
                            Name = "Lofi"

                        },

                        new Genres() {

                            Name = "Rap"

                        },

                        new Genres()
                        {

                            Name = "Pop"

                        },

                        new Genres()
                        {

                            Name = "Classic"

                        },

                        new Genres()
                        {

                            Name = "Countery"

                        }
                    });

                    db.SaveChanges();

                }

                //Songs

                if (!db.Songs.Any())
                {

                    
                        
                        
                        
                        
                        
                        
                        
                         

                }


                //Users

                if (!db.ApplicationUser.Any())
                {

                }


                //Playlists

                if (!db.PlayLists.Any())
                {

                }

                //Saved songs

                if (!db.Saved_Songs.Any())
                {

                }
            }
        }
    }
}
