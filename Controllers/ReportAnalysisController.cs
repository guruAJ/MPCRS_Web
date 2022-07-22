using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPCRS1.Data;
using MPCRS1.Models;
using System.Globalization;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ReportAnalysisController : Controller
    {

        public readonly ApplicationDbContext _context;
        public ReportAnalysisController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index ([Bind("fatalmilpers,fatalcivpers,nonfatalmil,nonfatacivil")] ProcessData processData)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(processData);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }




        public ActionResult List (ProcessDataSearch Db)
        {



            TempData["Alldata"] = _context.processDatas.ToList();
    
            return View();
        }
      
         
        DateTime dateVal;
        string[] date;
        public ActionResult ReportAnalysis (string FromDate, string ToDate ,string place,string station , string mod_op_facts, string fatalmilpers, string offence_desc, string UnitName, string Fmn)
        {
            //var Place  = Db.Place;
            //var Station  = Db.station; 
            //var Actiontaken  = Db.actiontaken;
            
            List<UnitDtl> Unit1  = new List<UnitDtl>();
            Unit1 = (from c in _context.mProunit select c).ToList();
            Unit1.Insert(0, new UnitDtl { Command = 0, UnitName = "--Select Unit Name--" }); 
            ViewBag.Unit = Unit1.ToList();



            List<tbl_offence> Offence1 = new List<tbl_offence>();
            Offence1 = (from c in _context.tbl_Offences select c).ToList();
            Offence1.Insert(0, new tbl_offence { offnsid = 0, offence_desc = "--Select Offence Name --" });
            ViewBag.Offence = Offence1.ToList();


            List<UnitDtl> fmn1 = new List<UnitDtl>();
            fmn1 = (from a in _context.mProunit select a).ToList();
            fmn1.Insert(0, new UnitDtl { Id = 0, Fmn = "Select fmn --" });
            ViewBag.fmn = fmn1.ToList();

            List<ProcessData> fatal1 = new List<ProcessData>();
            fatal1 = (from b in _context.processDatas select b).ToList();
            fatal1.Insert(0, new ProcessData { comdid=0, fatalmilpers = "--Select fatal--" });
            ViewBag.fatal = fatal1.ToList(); 

            {

                //int comdids = Convert.ToInt32(comdid);

                string DateString="2021-01-01";
                string ToDateString = "2022-12-01";





                var cards = (from c in _context.tbl_Offences
                             join d in _context.processDatas
                             on c.offence_code equals d.occuranceid
                             join e in _context.mProunit
                             on d.comdid equals e.Command

                             select new ReportAnalysis
                             {
                                 offencedt = d.offencedt,
                                 armyno_offen = d.armyno_offen,
                                 rank_offen = d.rank_offen,
                                 name_offen = d.name_offen,
                                 unit_offen = d.unit_offen,
                                 station_cmp = d.station_cmp,
                                 place = d.place,
                                 offence_desc = c.offence_desc,
                                 fmn_offen = d.fmn_offen,
                                 comdid = d.comdid,
                                 offenceid = c.offnsid,
                                 unitid = e.Command,
                                 fmn = e.Fmn,
                                 station = d.station,
                                 fatalmilpers = d.fatalmilpers,
                                 fatalcivpers = d.fatalcivpers,
                                 nonfatalmil = d.nonfatalmil,
                                 nonfatacivil = d.nonfatacivil,
                                 actiontaken = d.actiontaken,
                                 remarks = d.remarks,
                                 mod_op_facts =d.mod_op_facts



                             }).OrderByDescending(x => x.offencedt)
                              .ToList();
                if (FromDate != null && ToDate!=null)
                {
                    DateTime dt = Convert.ToDateTime(FromDate);
                    cards =cards.Where(r => r.offencedt >= Convert.ToDateTime(FromDate) && r.offencedt <= Convert.ToDateTime(ToDate)).ToList();
                }
                if(!string.IsNullOrEmpty(place))
                {
                    cards=cards.Where(r => r.place.Equals(place)).ToList();
                }
                if (!string.IsNullOrEmpty(station))
                {
                    cards=cards.Where(r => r.station.Equals(station)).ToList();
                }
                if (!string.IsNullOrEmpty(mod_op_facts))
                {
                    cards=cards.Where(r => r.mod_op_facts.Equals(mod_op_facts)).ToList();
                }
                if (!string.IsNullOrEmpty(fatalmilpers))
                {
                    if(Convert.ToInt32(fatalmilpers)!=0)
                    cards = cards.Where(r => r.comdid==Convert.ToInt32(fatalmilpers)).ToList();
                }
                if (!string.IsNullOrEmpty(offence_desc))
                {
                    if (Convert.ToInt32(offence_desc) != 0)
                        cards =cards.Where(r => r.offenceid == Convert.ToInt32(offence_desc)).ToList();
                }
                if (!string.IsNullOrEmpty(UnitName))
                {
                    if (Convert.ToInt32(UnitName) != 0)
                        cards =cards.Where(r => r.unitid == Convert.ToInt32(UnitName)).ToList();
                }
                if (!string.IsNullOrEmpty(Fmn))
                {
                    if (Convert.ToInt32(Fmn) != 0)
                        cards =cards.Where(r => r.station_cmp.Equals(Fmn)).ToList();
                }
                //
                TempData["cards"] = cards;
                
                return View();
            }
        }



    }
}







