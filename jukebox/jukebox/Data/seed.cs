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

                //Songs

                //Users

                //Playlists

                //Saved songs
            }
        }
    }
}
