using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MPCRS1.Models
{
    public class ProcessData
    {

        //[Column("comdid")]

        [Key]
        public string? offenceid { get; set; }
        public int comdid { get; set; }

        public string? firnumber { get; set; }
        public string? armyno_cmp { get; set; }
        public string? ranks_cmp { get; set; }
        public string? names_cmp { get; set; }
        public string? unitsid_cmp { get; set; }

        public int fmnid_cmp { get; set; }
        public string? occurance_offence { get; set; }
        public string? station { get; set; }
        public string? place { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime offencedt { get; set; }
        public string? offencetime { get; set; }
        public string? icardno_offen { get; set; }
        public string? milveh { get; set; }
        public string? civveh { get; set; }
        public string? fatalmilpers { get; set; }
        public string? fatalcivpers { get; set; }
        public string? nonfatalmil { get; set; }
        public string? nonfatacivil { get; set; }
        public string? armyno_offen { get; set; }
        public string? rank_offen { get; set; }
        public string? name_offen { get; set; }
        public string? unit_offen { get; set; }
        public string? address_offen { get; set; }
        public string? teleno_offen { get; set; }
        public string? vehbano_offen { get; set; }
        public string? vehmaketypeid_offen { get; set; }
        /*  public int vehmaketypeid_offen { get; set; } */    //1
        public string? fmn_offen { get; set; }
        public string? briefcase_offen { get; set; }
        public string? evidence_sketch { get; set; }
        public string? evidence_photo { get; set; }
        public string? evidence_video { get; set; }
        public string? docu_att { get; set; }
        public string? items { get; set; }
        public string? actiontaken { get; set; }
        public string? det_occu_repport { get; set; }
        public string? findings { get; set; }
        public string? remarksof_co_pro { get; set; }
        public string? mod_op_facts { get; set; }
        public string? station_cmp { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date_cmp { get; set; }
        public string? nameofCO { get; set; }
        public string? remarks { get; set; }
        public int report_type { get; set; }


        public string? veh_colour_offen { get; set; }
        public string? armyno_codvr { get; set; }
        public string? rank_codvr { get; set; }
        public string? Name_codvr { get; set; }
        public string? unit_codvr { get; set; }
        public string? fmn_codvr { get; set; }

        public string? address_codvr { get; set; }
        public string? veh_regnno { get; set; }
        public string? make_civ { get; set; }
        public string? colour { get; set; }
        public string? tactno { get; set; }
        public string? cmpduty_timeto { get; set; }

        public string? duty_of_cmp { get; set; }
        public string? jcno_cmpjco { get; set; }
        public string? rank_cmpjco { get; set; }
        public string? name_cmpjco { get; set; }
        public string? unit_cmpjco { get; set; }
        public string? cmpduty_timefrom { get; set; }
        public int occuranceid { get; set; }
        public string? speed_offe { get; set; }
        public string? overspeed_offe { get; set; }
        public string? speed_exc_offe { get; set; }
        public string? vehmake { get; set; }
        public string? evidences { get; set; }
        public string? documents { get; set; }
        public bool case_stat { get; set; }
        public string? unit_cmp { get; set; }
        public bool Checked { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]



        [Column("uploaddt")]
        public DateTime uploaddt { get; set; }


        [NotMapped]
        public string? offence_desc { get; set; }


    }
}
