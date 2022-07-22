using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class tbl_offence
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]



       
        [Column("Id")]
        public int  offnsid { get; set; }

        //[NotMapped]
        //public int offnsid { get; set; }



        public int offence_code { get; set; }
        public string? offence_desc { get; set; }
        public bool maj_offence { get; set; }
        public int Print_seq { get; set; }

    }
}
