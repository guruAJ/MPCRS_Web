using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class Contact
    {


        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]

        [Column("Name")]
        public string? Name  { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Message { get; set; }



    }
}
