using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class DispAnarep
    {


        [Key]
        public int Id { get; set; }

        public int comdid { get; set; }
        public int offence_code { get; set; }



        public string? offence_desc { get; set; }



        public bool maj_offences { get; set; }

        public DateTime offencedt { get; set; }

        //public string date { get; set; }
        public DateTime date { get; set; }
        public int occuranceid { get; set; }
        public int Total { get; set; }

        public int caseTotal { get; set; }



        public bool case_stat { get; set; }

        public string? remarks { get; set; }


    }
}
