
using jukebox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace jukebox.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayLists>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(c => c.PlayLists)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Saved_Songs>()
                .HasOne(p => p.Songs)
                .WithMany(c => c.Saved_Songs)
                .HasForeignKey(p => p.SongsId)
                .OnDelete(DeleteBehavior.NoAction);



            modelBuilder.Entity<Saved_Songs>()
                .HasOne(p => p.PlayLists)
                .WithMany(c => c.Saved_Songs)
                .HasForeignKey(p => p.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Songs>()
                .HasOne(p => p.Genres)
                .WithMany(c => c.Songs)
                .HasForeignKey(p => p.GenresId)
                .OnDelete(DeleteBehavior.Cascade);


            //Data seeding 


            //Songs table

            modelBuilder.Entity<Songs>().HasData(


                //I already added "Rap" and "Lofi" songs manualy 

                //POP songs

               new Songs {

                   Id = 7,

                   Name = "Thriller",

                   Length = TimeSpan.FromMinutes(5),

                   Artist = "Michael Jackson",

                   GenresId = 3
               },

               new Songs { 
                   
                   
                   Id = 8 ,

                   Name = "Take On Me",

                   Length = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(30),

                   Artist = " A-ha",

                   GenresId = 3
               },

               new Songs
               {

                   Id = 9,

                   Name = "Beat It",

                   Length = TimeSpan.FromMinutes(4) + TimeSpan.FromSeconds(48),

                   Artist = "Michael Jackson",

                   GenresId = 3
               },


               //Classic songs

               new Songs()
               {
                   Id= 10,

                   Name = "Hotel California",

                   Length = TimeSpan.FromMinutes(6),

                   Artist = "Eagles ",

                   GenresId = 4
               },

               new Songs()
                {

                    Id = 11,

                    Name = "Respect",

                    Length = TimeSpan.FromMinutes(2) + TimeSpan.FromSeconds(10),

                    Artist = "Otis redding",

                    GenresId = 4
                },

               new Songs()
                {
                    Id = 12 ,

                    Name = "I will survive",

                    Length = TimeSpan.FromMinutes(3) + TimeSpan.FromSeconds(13),

                    Artist = "Freddie perren",

                    GenresId = 4

                },


                //Countery songs

               new Songs()
                {

                    Id = 13 ,

                    Name = "I Walk the Line",

                    Length = TimeSpan.FromMinutes(4),

                    Artist = "Johnny Cash",

                    GenresId = 5
                },

               new Songs()
                {

                    Id = 14 ,

                    Name = "Jolene",

                    Length = TimeSpan.FromMinutes(3) + TimeSpan.FromSeconds(35),

                    Artist = "Dolly Parton",

                    GenresId = 5
                },

               new Songs()
                {

                    Id = 15 ,

                    Name = "Friends in Low Places",

                    Length = TimeSpan.FromMinutes(5),

                    Artist = "Garth Brooks",

                    GenresId = 5

                }
           );


            //Playlist table

            modelBuilder.Entity<PlayLists>().HasData(


                new PlayLists()
                {
                    Id= 40 ,

                    Name = "Lofi",

                    UserId = "bd1d889c-0482-4a8c-ac22-dfa0769f95a8"

                },

                new PlayLists()
                {

                    Id = 41 ,

                    Name = "Rap",

                    UserId = "bd1d889c-0482-4a8c-ac22-dfa0769f95a8"

                },

                new PlayLists()
                {

                    Id = 42 ,

                    Name = "Lofi",

                    UserId = "aa164a31-0ce0-47f3-945d-577a9625affb"

                },

                new PlayLists()
                {

                    Id = 43 ,

                    Name = "Rap",

                    UserId = "aa164a31-0ce0-47f3-945d-577a9625affb"

                },

                new PlayLists()
                {
                    Id = 45 ,

                    Name = "Lofi",

                    UserId = "fa970c7f-7425-4bba-96bc-5502113f858b"

                },

                new PlayLists()
                {

                    Id = 46 ,

                    Name = "Rap",

                    UserId = "fa970c7f-7425-4bba-96bc-5502113f858b"

                }


            );

            //Saved_songs table

            modelBuilder.Entity<Saved_Songs>().HasData(


                new Saved_Songs() {

                    Id = 100 ,

                    PlaylistId = 21 ,

                    SongsId = 2

                },

                new Saved_Songs() {

                    Id = 101 ,

                    PlaylistId = 21 ,

                    SongsId = 2

                },

                new Saved_Songs() {

                    Id = 102 ,

                    PlaylistId = 31 ,

                    SongsId = 3

                },

                new Saved_Songs() {

                    Id = 110 ,

                    PlaylistId = 31 ,

                    SongsId = 4

                },

                new Saved_Songs() {

                    Id = 114 ,

                    PlaylistId = 31 ,

                    SongsId = 5

                },

                new Saved_Songs() {

                    Id = 125 ,

                    PlaylistId = 31 ,

                    SongsId = 6

                }

            );


        }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<PlayLists> PlayLists { get; set; }

        public DbSet<Songs> Songs { get; set; }

        public DbSet<Saved_Songs> Saved_Songs { get; set;}

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
