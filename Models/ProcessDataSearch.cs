using System.ComponentModel.DataAnnotations;

namespace MPCRS1.Models
{
    public class ProcessDataSearch
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }



        public string? UnitName { get; set; }

        public string ? fatal { get; set; }
        public string ? fmn { get; set; }   
        public string ? Place { get; set; }
        public string ?comdid { get; set; }
        public string? actiontaken { get; set; }
        public string ? station { get; set; }
        public string? remarks { get; set; }
        public int? offenceid { get; set; }
        //offenceid
    }
}
