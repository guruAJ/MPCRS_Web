using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class UploadDtl
    {

        [Key]
        [Column("UnitId")]
        public int UnitId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        [Column("Unitname")]
        public string? UnitName { get; set; }

        [Required]
        [Column("FileName")]
        public string? FileName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        //[RegularExpression(@"([0-9][0-9])\/([0-9][0-9])")]
        [Column("uploaddt")]
        public DateTime uploaddt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        //[RegularExpression(@"([0-9][0-9])\/([0-9][0-9])")]
        [Column("processeddt")]
        public DateTime processeddt { get; set; }

        [Required]
        [Column("TotalRec")]
        public int TotalRecords { get; set; }


        [Required]
        [Column("RejectedRec")]
        public int RejectedRecords { get; set; }
    }
}
