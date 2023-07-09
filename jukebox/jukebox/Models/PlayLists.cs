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

        [Column(TypeName = "VARCHAR")]

        [StringLength(50)]

        public string Name { get; set; }


        public string UserId { get; set; } // foreign key property
        public ApplicationUser ApplicationUser { get; set; }



    }
}
