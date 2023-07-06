
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace jukebox.Models
{
    public class PlayLists
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]

        public Songs Songs { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
