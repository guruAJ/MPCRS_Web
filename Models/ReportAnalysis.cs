using System.ComponentModel.DataAnnotations;

namespace MPCRS1.Models
{
    public class ReportAnalysis
    {
        //public List<ProcessData> ReportProcessData { get; internal set; }
        //public List<ProcessDataSearch> ProcessDataSearch  { get; internal set; }


        public int  offence_code { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime offencedt { get; set; }
        public string? armyno_offen { get; set; }
        public string? rank_offen { get; set; }
        public string? name_offen { get; set; }
        public string? unit_offen { get; set; }
        public string? station_cmp { get; set; }
        public string? place { get; set; }

        public string? offence_desc { get; set; }
        public string? fmn_offen { get; set; }
        public string? fatalmilpers { get; set; }
        public string? fatalcivpers { get; set; }
        public string? nonfatalmil { get; set; }
        public string? nonfatacivil { get; set; }

        public string? actiontaken { get; set; }
        public int? comdid { get; set; }
        public int? offenceid { get; set; }
        public int? unitid { get; set; }
        public string? fmn { get; set; }

        public string? station { get; set; }

        public string? mod_op_facts { get; set; }




        public string? remarks { get; set; }

        public string? fatal { get; set; }
        

        //comdid











        public string? UnitName { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }
    }
}


