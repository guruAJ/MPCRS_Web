
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCRS1.Data;
using MPCRS1.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class SummaryMpReportsController : Controller
    {
        public readonly ApplicationDbContext _context;
        private object tempProcessesDataQuery;

        public SummaryMpReportsController(ApplicationDbContext context)
        {
            _context = context;
        }



        List<tbl_offence> tbl_Offences = new List<tbl_offence>();
        List<ProcessData> processDatas = new List<ProcessData>();






        public IActionResult Index()
        {



            List<DispAnarep> Employee = new List<DispAnarep>();



            //DateTime todaysss = DateTime.Now.AddMonths(-6);
            DateTime todaysss = DateTime.Now;


            DateTime startDate = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek), // prev sunday 00:00
            endDate = startDate.AddDays(-180); // next sunday 00:00



            var Emp = (from E1 in _context.processDatas
                       join E2 in _context.tbl_Offences
                        on E1.occuranceid equals E2.offence_code
                       where //E1.offencedt.Month == todaysss.Month && E1.offencedt.Year == todaysss.Year
                        E1.offencedt <= todaysss && E1.offencedt >= endDate


                       group E1 by new { month = E1.offencedt.Month, year = E1.offencedt.Year } into g





                       /* select new  })*/
                       select new DispAnarep

                       {
                           caseTotal = g.Count(E1 => E1.case_stat == true),



                           date = DateTime.Parse(string.Format("{0} {1}", g.Key.month, g.Key.year)),
                           Total = g.Count(E1 => E1.case_stat == false),

                           /*g.Count(Convert.ToInt32(g.Key.case_stat))*/





                       }).ToList();

            ViewBag.MpReport = Emp;





            return View();




        }

        public IActionResult DiscpAnalysis_BarChart ()
        {


            DateTime baseDate = DateTime.Today;
            var today = baseDate;
            var currentMonth = today.Month;
            var thisMonthStart = baseDate.AddMonths(-(int)today.Month);
             




            thisMonthStart = thisMonthStart.AddMonths(1);
            var offencedt = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == true  && E1.offencedt.Year == thisMonthStart.Date.Year && E1.offencedt.Month == thisMonthStart.Date.Month group E2 by E2.offence_code).Count();
            ViewData["Jan"] = offencedt;

            thisMonthStart = thisMonthStart.AddMonths(1);
            var Feb = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == true && E1.offencedt.Year == thisMonthStart.Date.Year && E1.offencedt.Month == thisMonthStart.Date.Month group E2 by E2.offence_code).Count();
            ViewData["Feb"] = Feb;



            thisMonthStart = thisMonthStart.AddMonths(1);
            var March  = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == true && E1.offencedt.Year == thisMonthStart.Date.Year && E1.offencedt.Month == thisMonthStart.Date.Month group E2 by E2.offence_code).Count();
            ViewData["March"] = March;

            thisMonthStart = thisMonthStart.AddMonths(1);
            var April  = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == true && E1.offencedt.Year == thisMonthStart.Date.Year && E1.offencedt.Month == thisMonthStart.Date.Month group E2 by E2.offence_code).Count();
            ViewData["April"] = April;


            thisMonthStart = thisMonthStart.AddMonths(1);
            var May = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == true && E1.offencedt.Year == thisMonthStart.Date.Year && E1.offencedt.Month == thisMonthStart.Date.Month group E2 by E2.offence_code).Count();
            ViewData["May"] = May;


            thisMonthStart = thisMonthStart.AddMonths(1);
            var June  = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == true && E1.offencedt.Year == thisMonthStart.Date.Year && E1.offencedt.Month == thisMonthStart.Date.Month group E2 by E2.offence_code).Count();
            ViewData["June"] = June;






            DateTime baseDate1 = DateTime.Today;
            var today1 = baseDate1;
            var currentMonth1 = today.Month;
            var thisMonthStart1 = baseDate1.AddMonths(-(int)today.Month);





            thisMonthStart1 = thisMonthStart1.AddMonths(1);
            var Jan1 = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == false && E1.offencedt.Year == thisMonthStart1.Date.Year && E1.offencedt.Month == thisMonthStart1.Date.Month group E2 by E2.offence_code).Count();
            ViewData["Jan1"] = Jan1;

            thisMonthStart1 = thisMonthStart1.AddMonths(1);
            var Feb1 = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == false && E1.offencedt.Year == thisMonthStart1.Date.Year && E1.offencedt.Month == thisMonthStart1.Date.Month group E2 by E2.offence_code).Count();
            ViewData["Feb1"] = Feb1;



            thisMonthStart1 = thisMonthStart1.AddMonths(1);
            var March1 = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == false && E1.offencedt.Year == thisMonthStart1.Date.Year && E1.offencedt.Month == thisMonthStart1.Date.Month group E2 by E2.offence_code).Count();
            ViewData["March1"] = March1;

            thisMonthStart1 = thisMonthStart1.AddMonths(1);
            var April1 = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == false && E1.offencedt.Year == thisMonthStart1.Date.Year && E1.offencedt.Month == thisMonthStart1.Date.Month group E2 by E2.offence_code).Count();
            ViewData["April1"] = April1;


            thisMonthStart1 = thisMonthStart1.AddMonths(1);
            var May1 = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == false && E1.offencedt.Year == thisMonthStart1.Date.Year && E1.offencedt.Month == thisMonthStart1.Date.Month group E2 by E2.offence_code).Count();
            ViewData["May1"] = May1;


            thisMonthStart1 = thisMonthStart1.AddMonths(1);
            var June1 = (from E1 in _context.processDatas join E2 in _context.tbl_Offences on E1.occuranceid equals E2.offence_code where E2.maj_offence == false && E1.offencedt.Year == thisMonthStart1.Date.Year && E1.offencedt.Month == thisMonthStart1.Date.Month group E2 by E2.offence_code).Count();
            ViewData["June1"] = June1;















            //var Chart1 = _context.tbl_Offences.Count(E2 => E2.maj_offence == true).ToString();


            //ViewData["Major"] = Chart1;



            //var chart3 = _context.tbl_Offences.Count(E2 => E2.maj_offence != true).ToString();
            //ViewData["Minor"] = chart3;



         
            return View();

        }







        public IActionResult ComdWiseReport (string comdid)
        {

            List<tbl_Comd> cl = new List<tbl_Comd>();
            cl = (from c in _context.tbl_Comds select c).ToList();
            cl.Insert(0, new tbl_Comd { comdid = 0, Command = "--Select Command Name--" });
            ViewBag.cl = cl.ToList();

            int comdids = Convert.ToInt32(comdid);

            List<DispAnarep> Employee = new List<DispAnarep>();

            DateTime todaysss = DateTime.Now;

            if (comdids > 0)
            {


             


                DateTime startDate = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek), // prev sunday 00:00
                endDate = startDate.AddDays(-180); // next sunday 00:00



                var Emp = (from E1 in _context.processDatas
                           join E2 in _context.tbl_Offences
                            on E1.occuranceid equals E2.offence_code
                           where //E1.offencedt.Month == todaysss.Month && E1.offencedt.Year == todaysss.Year
                            E1.offencedt <= todaysss && E1.offencedt >= endDate && E1.comdid == comdids


                           group E1 by new { month = E1.offencedt.Month, year = E1.offencedt.Year } into g





                           /* select new  })*/
                           select new DispAnarep

                           {
                               caseTotal = g.Count(E1 => E1.case_stat == true),



                               date = DateTime.Parse(string.Format("{0} {1}", g.Key.month, g.Key.year)),
                               Total = g.Count(E1 => E1.case_stat == false),

                               /*g.Count(Convert.ToInt32(g.Key.case_stat))*/





                           }).ToList();

                ViewBag.MpReport = Emp;


            }


            else
            {




                DateTime startDate = DateTime.Today.Date.AddDays(-(int)DateTime.Today.DayOfWeek), // prev sunday 00:00
                endDate = startDate.AddDays(-180); // next sunday 00:00



                var Emp = (from E1 in _context.processDatas
                           join E2 in _context.tbl_Offences
                            on E1.occuranceid equals E2.offence_code
                           where //E1.offencedt.Month == todaysss.Month && E1.offencedt.Year == todaysss.Year
                            E1.offencedt <= todaysss && E1.offencedt >= endDate


                           group E1 by new { month = E1.offencedt.Month, year = E1.offencedt.Year } into g





                           /* select new  })*/
                           select new DispAnarep

                           {
                               caseTotal = g.Count(E1 => E1.case_stat == true),



                               date = DateTime.Parse(string.Format("{0} {1}", g.Key.month, g.Key.year)),
                               Total = g.Count(E1 => E1.case_stat == false),

                               /*g.Count(Convert.ToInt32(g.Key.case_stat))*/





                           }).ToList();

                ViewBag.MpReport = Emp;


            }


            return View();




        }
       


    }
}

