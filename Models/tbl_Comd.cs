using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class tbl_Comd
    {
        [Key]
        public int comdid { get; set; }

        [Required]
        [Column("comdName")]
        public string? Command { get; set; }
    }
}
