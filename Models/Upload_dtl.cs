
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class Upload_dtl
    {


        [Key]
        [Column("UploadId")]
        public int Id { get; set; }


        [Column("FileName")]
        public string? FileName { get; set; }

        [Required]
        [Column("UploadedBy")]
        public string? UploadedBy { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
       
        [Column("uploaddt")]
        public DateTime uploaddt { get; set; }

        public bool ProcessData { get; set; }


    }

    public class CreateUpload_dtl
    {
        public IFormFile? postedFiles { get; set; }
     
    }
}





