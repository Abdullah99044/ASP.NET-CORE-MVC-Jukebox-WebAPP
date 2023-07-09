using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace jukebox.Models
{
    public class ApplicationUser : IdentityUser
    {
 
        public ICollection<PlayLists> PlayLists { get; set; }

    }
}
