
using jukebox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
                .HasForeignKey(p => p.UserId);
        }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<PlayLists> PlayLists { get; set; }

        public DbSet<Songs> Songs { get; set; }

         
    }
}
