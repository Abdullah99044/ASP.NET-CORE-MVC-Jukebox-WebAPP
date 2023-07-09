using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace jukebox.Models
{
    public class ApplicationUser : IdentityUser
    {
 
        public ICollection<PlayLists> PlayLists { get; set; }

        public ICollection<Saved_Songs> Saved_Songs { get; set; }


    }
}
