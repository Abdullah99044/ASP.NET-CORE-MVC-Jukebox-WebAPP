using System.ComponentModel.DataAnnotations;

namespace jukebox.Models
{
    public class Saved_Songs
    {
        [Key]

        public int Id { get; set; }



        public int PlaylistId { get; set; }

        public PlayLists PlayLists { get; set; }



        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
