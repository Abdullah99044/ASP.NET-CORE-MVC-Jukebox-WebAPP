﻿
using jukebox.Models;
using Microsoft.EntityFrameworkCore;
namespace jukebox.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Genres> Genres { get; set; }
    }
}
