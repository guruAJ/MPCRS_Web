using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class UnitDtl
    {
        [Key]
        [Column("unitid")]
        public int Id { get; set; }

        [Required]
    
        [Column("unitname")]
        public string? UnitName { get; set; }
        
        public int Command  { get; set; }


        [Required]

        [Column("unitcode")]


        public string? UnitCode { get; set; }

        [Required]
        [Column("area_loc")]
        public string? Location { get; set; }

        [Required]
        [Column("fmn")]
        public string? Fmn { get; set; }

       

        //[Required]
        [Column("status")]
        public bool? Status { get; set; }

        [Required]

        [Column("updatedby")]
        public string? UpdatedBy { get; set; }

        [Required]
        //[DataType(DataType.DateTime)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
     
        [Column("updateddt")]
        public DateTime UpdatedDate { get; set; }

        [NotMapped]
        public string ? CommandName { get; set; }


        //public tbl_Comd tbl_Comd { get; set; }

        //[NotMapped]
        //public int comdid { get; set; }

    }
}