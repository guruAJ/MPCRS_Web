using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPCRS1.Data;
using MPCRS1.Models;
using System.Linq;


namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DiscpAnalysisReportController : Controller

    {

        public readonly ApplicationDbContext _context;
        public DiscpAnalysisReportController(ApplicationDbContext context)
        {
            _context = context;
        }


        List<tbl_offence> tbl_Offences = new List<tbl_offence>();
        List<ProcessData> processDatas = new List<ProcessData>();


        public async Task<ActionResult> SHOW()
        {
            var ajay = await _context.tbl_Offences.Where(x => x.offnsid == 1).FirstOrDefaultAsync();


            return View(ajay);
        }

        public async Task<IActionResult> Index(string comdid)
        {
            List<tbl_Comd> cl = new List<tbl_Comd>();
            cl = (from c in _context.tbl_Comds select c).ToList();
            cl.Insert(0, new tbl_Comd { comdid = 0, Command = "--Select Command Name--" });
            ViewBag.cl = cl.ToList();

            int comdids = Convert.ToInt32(comdid);

            List<DispAnarep> Employee = new List<DispAnarep>();


            var maj_offence = from offence_desc in _context.tbl_Offences
                              where offence_desc.maj_offence == true
                              select offence_desc;

            ViewBag.maj_offence = maj_offence;

            var min_offence = from offence_desc in _context.tbl_Offences
                              where offence_desc.maj_offence == false
                              select offence_desc;

            ViewBag.min_offence = min_offence;

            var offnc = _context.tbl_Offences.ToList();
            //int a = Convert.ToInt32(id);

            DateTime todays = DateTime.Now;
            //int i = 1;

            if (comdids > 0)
            {
                var Emp = (from E1 in _context.tbl_Offences
                           join E2 in _context.processDatas
                           on E1.offence_code equals E2.occuranceid

                           //join E3 in _context.mProunit on E2.comdid equals E3.Command
                           where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todays.Month && E2.offencedt.Year == todays.Year

                           group new { E1, E2 } by new
                           {
                               E1.offence_code,
                               E2.comdid,
                               E1.offence_desc

                           } into g


                           select new DispAnarep
                           {
                               offence_code = g.Key.offence_code,
                               comdid = g.Key.comdid,
                               offence_desc = g.Key.offence_desc,

                               Total = g.Count()
                           });

                ViewBag.majorCount = Emp;





                DateTime today = DateTime.Now;

                var Emp1 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid

                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == today.Month && E2.offencedt.Year == today.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,
                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCount = Emp1;


                //previous Months


                DateTime todaysss = DateTime.Now.AddMonths(-1);

                var Emp2 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todaysss.Month && E2.offencedt.Year == todaysss.Year

                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count()
                            });

                ViewBag.majorCountpre = Emp2;



                DateTime todayss = DateTime.Now.AddMonths(-1);

                var Emp3 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == todayss.Month && E2.offencedt.Year == todayss.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCountpre = Emp3;


         


                // Action Taken

                DateTime todaY = DateTime.Today;

                var Emp6 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todaY.Month && E2.offencedt.Year == todaY.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,
                                Total = g.Count(),




                            });

                ViewBag.Casestatemaj = Emp6;



                DateTime todaYs = DateTime.Today;

                var Emp7 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == todaYs.Month && E2.offencedt.Year == todaYs.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.Casestatemin = Emp7;


                //action taken previous months


                DateTime Today = DateTime.Now.AddMonths(-1);

                var Emp8 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today.Month && E2.offencedt.Year == Today.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestatemajPre = Emp8;



                DateTime Todays = DateTime.Now.AddMonths(-1);

                var Emp9 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == Todays.Month && E2.offencedt.Year == Todays.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestateminPre = Emp9;

            }
            else
            {




                var Emp = (from E1 in _context.tbl_Offences
                           join E2 in _context.processDatas
                           on E1.offence_code equals E2.occuranceid

                           //join E3 in _context.mProunit on E2.comdid equals E3.Command
                           where E1.maj_offence == true && E2.offencedt.Month == todays.Month && E2.offencedt.Year == todays.Year

                           group new { E1, E2 } by new
                           {
                               E1.offence_code,
                               E2.comdid,
                               E1.offence_desc

                           } into g


                           select new DispAnarep
                           {
                               offence_code = g.Key.offence_code,
                               comdid = g.Key.comdid,
                               offence_desc = g.Key.offence_desc,

                               Total = g.Count()
                           });

                ViewBag.majorCount = Emp;





                DateTime today = DateTime.Now;

                var Emp1 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit
                            //on E2.unitsid_cmp equals E3.UnitCode
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == today.Month && E2.offencedt.Year == today.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,
                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCount = Emp1;


                //previous Months


                DateTime todaysss = DateTime.Now.AddMonths(-1);

                var Emp2 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.offencedt.Month == todaysss.Month && E2.offencedt.Year == todaysss.Year

                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count()
                            });

                ViewBag.majorCountpre = Emp2;



                DateTime todayss = DateTime.Now.AddMonths(-1);

                var Emp3 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == todayss.Month && E2.offencedt.Year == todayss.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCountpre = Emp3;




                // Action Taken

                DateTime todaY = DateTime.Today;

                var Emp6 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.offencedt.Month == todaY.Month && E2.offencedt.Year == todaY.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,
                                Total = g.Count(),




                            });

                ViewBag.Casestatemaj = Emp6;



                DateTime todaYs = DateTime.Today;

                var Emp7 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == todaYs.Month && E2.offencedt.Year == todaYs.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.Casestatemin = Emp7;


                //action taken previous months


                DateTime Today = DateTime.Now.AddMonths(-1);

                var Emp8 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.offencedt.Month == Today.Month && E2.offencedt.Year == Today.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestatemajPre = Emp8;



                DateTime Todays = DateTime.Now.AddMonths(-1);

                var Emp9 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == Todays.Month && E2.offencedt.Year == Todays.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestateminPre = Emp9;

            }




            return View();

        }



        public async Task<IActionResult> Index2 (string comdid)
        {
            List<tbl_Comd> cl = new List<tbl_Comd>();
            cl = (from c in _context.tbl_Comds select c).ToList();
            cl.Insert(0, new tbl_Comd { comdid = 0, Command = "--Select Command Name--" });
            ViewBag.cl = cl.ToList();

            int comdids = Convert.ToInt32(comdid);

            List<DispAnarep> Employee = new List<DispAnarep>();


            var maj_offence = from offence_desc in _context.tbl_Offences
                              where offence_desc.maj_offence == true
                              select offence_desc;

            ViewBag.maj_offence = maj_offence;

            var min_offence = from offence_desc in _context.tbl_Offences
                              where offence_desc.maj_offence == false
                              select offence_desc;

            ViewBag.min_offence = min_offence;

            var offnc = _context.tbl_Offences.ToList();
            //int a = Convert.ToInt32(id);

            DateTime todays = DateTime.Now;
            //int i = 1;

            if (comdids > 0)
            {
                var Emp = (from E1 in _context.tbl_Offences
                           join E2 in _context.processDatas
                           on E1.offence_code equals E2.occuranceid

                           //join E3 in _context.mProunit on E2.comdid equals E3.Command
                           where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todays.Month && E2.offencedt.Year == todays.Year

                           group new { E1, E2 } by new
                           {
                               E1.offence_code,
                               E2.comdid,
                               E1.offence_desc

                           } into g


                           select new DispAnarep
                           {
                               offence_code = g.Key.offence_code,
                               comdid = g.Key.comdid,
                               offence_desc = g.Key.offence_desc,

                               Total = g.Count()
                           });

                ViewBag.majorCount = Emp;





                DateTime today = DateTime.Now;

                var Emp1 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid

                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == today.Month && E2.offencedt.Year == today.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,
                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCount = Emp1;


                //previous Months


                DateTime todaysss = DateTime.Now.AddMonths(-1);

                var Emp2 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todaysss.Month && E2.offencedt.Year == todaysss.Year

                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count()
                            });

                ViewBag.majorCountpre = Emp2;



                DateTime todayss = DateTime.Now.AddMonths(-1);

                var Emp3 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == todayss.Month && E2.offencedt.Year == todayss.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCountpre = Emp3;




                // Quaterly (Three Months)



              
                var Quat2 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid
                      

                             where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-3) 
                             //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todaysss3.Month && E2.offencedt.Year == todaysss3.Year

                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count()
                             });

                ViewBag.majorCountQuaterly = Quat2;




                var Quat3 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid
                      
                             //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == todayss3.Month && E2.offencedt.Year == todayss3.Year

                             where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-3)


                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count(),




                             });

                ViewBag.minorCountQuaterly = Quat3;


                // Half Yearly (Six Months)





                var half1 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid

                             //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == today_half.Month && E2.offencedt.Year == today_half.Year

                             where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-6)



                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count()
                             });

                ViewBag.majorCountHalfYearly = half1;





                var half2 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid

                             //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == today_half1.Month && E2.offencedt.Year == today_half1.Year
                             where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-6)

                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count(),




                             });

                ViewBag.minorCountHalfYearly = half2;




                //  Yearly (Twelve Months)



              

                var Year1 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid
                            
                             //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == today_Year.Month && E2.offencedt.Year == today_Year.Year
                             where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-12)

                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count()
                             });

                ViewBag.majorCountYearly = Year1;



                

                var Year2 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid

                             //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == today_Year1.Month && E2.offencedt.Year == today_Year1.Year
                             where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-12)


                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count(),




                             });

                ViewBag.minorCountYearly = Year2;



                // Action Taken

                DateTime todaY = DateTime.Today;

                var Emp6 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todaY.Month && E2.offencedt.Year == todaY.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,
                                Total = g.Count(),




                            });

                ViewBag.Casestatemaj = Emp6;



                DateTime todaYs = DateTime.Today;

                var Emp7 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == todaYs.Month && E2.offencedt.Year == todaYs.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.Casestatemin = Emp7;


                //action taken previous months


                DateTime Today = DateTime.Now.AddMonths(-1);

                var Emp8 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today.Month && E2.offencedt.Year == Today.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestatemajPre = Emp8;



                DateTime Todays = DateTime.Now.AddMonths(-1);

                var Emp9 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == Todays.Month && E2.offencedt.Year == Todays.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestateminPre = Emp9;



                //action taken Quaterly months


            

                var Quaterly_action  = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                          
                            //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today3.Month && E2.offencedt.Year == Today3.Year && E2.case_stat == true
                               where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-3) && E2.case_stat == true

                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestatemajQuaterly = Quaterly_action;





               


           

               

                var Quaterly_action3 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-3) && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestateminQuaterly = Quaterly_action3;


                //action taken Half Yearly six months


                var HalfYearly_action = (from E1 in _context.tbl_Offences
                                       join E2 in _context.processDatas
                                       on E1.offence_code equals E2.occuranceid
                                      
                                       //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today_Half.Month && E2.offencedt.Year == Today_Half.Year && E2.case_stat == true
                                         where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-6) && E2.case_stat == true

                                         group new { E1, E2 } by new
                                       {
                                           E1.offence_code,
                                           E2.comdid,
                                           E1.offence_desc,

                                       } into g


                                       select new DispAnarep
                                       {
                                           offence_code = g.Key.offence_code,
                                           comdid = g.Key.comdid,
                                           offence_desc = g.Key.offence_desc,

                                           Total = g.Count(),




                                       });

                ViewBag.CasestatemajHalfYearly = HalfYearly_action;



             

                var HalfYearly_action6 = (from E1 in _context.tbl_Offences
                                        join E2 in _context.processDatas
                                        on E1.offence_code equals E2.occuranceid
                                        
                                        //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == Today_Half1.Month && E2.offencedt.Year == Today_Half1.Year && E2.case_stat == true
                                          where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-6) && E2.case_stat == true

                                          group new { E1, E2 } by new
                                        {
                                            E1.offence_code,
                                            E2.comdid,
                                            E1.offence_desc,

                                        } into g


                                        select new DispAnarep
                                        {
                                            offence_code = g.Key.offence_code,
                                            comdid = g.Key.comdid,
                                            offence_desc = g.Key.offence_desc,

                                            Total = g.Count(),




                                        });

                ViewBag.CasestateminHalfYearly = HalfYearly_action6;




                //action taken  Yearly Twelve months


              

                var Yearly_action = (from E1 in _context.tbl_Offences
                                         join E2 in _context.processDatas
                                         on E1.offence_code equals E2.occuranceid
                                        
                                         //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today_Yearly.Month && E2.offencedt.Year == Today_Yearly.Year && E2.case_stat == true
                                     where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-12) && E2.case_stat == true

                                     group new { E1, E2 } by new
                                         {
                                             E1.offence_code,
                                             E2.comdid,
                                             E1.offence_desc,

                                         } into g


                                         select new DispAnarep
                                         {
                                             offence_code = g.Key.offence_code,
                                             comdid = g.Key.comdid,
                                             offence_desc = g.Key.offence_desc,

                                             Total = g.Count(),




                                         });

                ViewBag.CasestatemajYearly = Yearly_action;




                var Yearly_action12 = (from E1 in _context.tbl_Offences
                                          join E2 in _context.processDatas
                                          on E1.offence_code equals E2.occuranceid
                                          
                                          //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == Today_Yearly1.Month && E2.offencedt.Year == Today_Yearly1.Year && E2.case_stat == true
                                       where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt > DateTime.Now.AddMonths(-12) && E2.case_stat == true

                                       group new { E1, E2 } by new
                                          {
                                              E1.offence_code,
                                              E2.comdid,
                                              E1.offence_desc,

                                          } into g


                                          select new DispAnarep
                                          {
                                              offence_code = g.Key.offence_code,
                                              comdid = g.Key.comdid,
                                              offence_desc = g.Key.offence_desc,

                                              Total = g.Count(),




                                          });

                ViewBag.CasestateminYearly = Yearly_action12;







            }
            else
            {




                var Emp = (from E1 in _context.tbl_Offences
                           join E2 in _context.processDatas
                           on E1.offence_code equals E2.occuranceid

                           //join E3 in _context.mProunit on E2.comdid equals E3.Command
                           where E1.maj_offence == true && E2.offencedt.Month == todays.Month && E2.offencedt.Year == todays.Year

                           group new { E1, E2 } by new
                           {
                               E1.offence_code,
                               E2.comdid,
                               E1.offence_desc

                           } into g


                           select new DispAnarep
                           {
                               offence_code = g.Key.offence_code,
                               comdid = g.Key.comdid,
                               offence_desc = g.Key.offence_desc,

                               Total = g.Count()
                           });

                ViewBag.majorCount = Emp;





                DateTime today = DateTime.Now;

                var Emp1 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit
                            //on E2.unitsid_cmp equals E3.UnitCode
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == today.Month && E2.offencedt.Year == today.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,
                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCount = Emp1;


                //previous Months


                DateTime todaysss = DateTime.Now.AddMonths(-1);

                var Emp2 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.offencedt.Month == todaysss.Month && E2.offencedt.Year == todaysss.Year

                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count()
                            });

                ViewBag.majorCountpre = Emp2;



                DateTime todayss = DateTime.Now.AddMonths(-1);

                var Emp3 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == todayss.Month && E2.offencedt.Year == todayss.Year


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.minorCountpre = Emp3;



                // Quaterly (Three Months)




                var Quat2 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid


                             where E1.maj_offence == true && E2.offencedt > DateTime.Now.AddMonths(-3)
                             //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == todaysss3.Month && E2.offencedt.Year == todaysss3.Year

                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count()
                             });

                ViewBag.majorCountQuaterly = Quat2;




                var Quat3 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid

                             //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == todayss3.Month && E2.offencedt.Year == todayss3.Year

                             where E1.maj_offence == false  && E2.offencedt > DateTime.Now.AddMonths(-3)


                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count(),




                             });

                ViewBag.minorCountQuaterly = Quat3;



                // Half Yearly (Six Months)



               

                var half1 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid
                            
                             //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == today_half.Month && E2.offencedt.Year == today_half.Year

                             where E1.maj_offence == true  && E2.offencedt > DateTime.Now.AddMonths(-6)



                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count()
                             });

                ViewBag.majorCountHalfYearly = half1;



               

                var half2  = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid
                           
                              //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == today_half1.Month && E2.offencedt.Year == today_half1.Year
                              where E1.maj_offence == false  && E2.offencedt > DateTime.Now.AddMonths(-6)

                              group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count(),




                             });

                ViewBag.minorCountHalfYearly = half2;



                //  Yearly (Twelve Months)





                var Year1 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid

                             //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == today_Year.Month && E2.offencedt.Year == today_Year.Year
                             where E1.maj_offence == true && E2.offencedt > DateTime.Now.AddMonths(-12)

                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count()
                             });

                ViewBag.majorCountYearly = Year1;





                var Year2 = (from E1 in _context.tbl_Offences
                             join E2 in _context.processDatas
                             on E1.offence_code equals E2.occuranceid

                             //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == today_Year1.Month && E2.offencedt.Year == today_Year1.Year
                             where E1.maj_offence == false  && E2.offencedt > DateTime.Now.AddMonths(-12)


                             group new { E1, E2 } by new
                             {
                                 E1.offence_code,
                                 E2.comdid,
                                 E1.offence_desc,

                             } into g


                             select new DispAnarep
                             {
                                 offence_code = g.Key.offence_code,
                                 comdid = g.Key.comdid,
                                 offence_desc = g.Key.offence_desc,

                                 Total = g.Count(),




                             });

                ViewBag.minorCountYearly = Year2;


                // Action Taken

                DateTime todaY = DateTime.Today;

                var Emp6 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                          
                            where E1.maj_offence == true && E2.offencedt.Month == todaY.Month && E2.offencedt.Year == todaY.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,
                                Total = g.Count(),




                            });

                ViewBag.Casestatemaj = Emp6;



                DateTime todaYs = DateTime.Today;

                var Emp7 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == todaYs.Month && E2.offencedt.Year == todaYs.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.Casestatemin = Emp7;


                //action taken previous months


                DateTime Today = DateTime.Now.AddMonths(-1);

                var Emp8 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == true && E2.offencedt.Month == Today.Month && E2.offencedt.Year == Today.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestatemajPre = Emp8;



                DateTime Todays = DateTime.Now.AddMonths(-1);

                var Emp9 = (from E1 in _context.tbl_Offences
                            join E2 in _context.processDatas
                            on E1.offence_code equals E2.occuranceid
                            //join E3 in _context.mProunit on E2.comdid equals E3.Command
                            where E1.maj_offence == false && E2.offencedt.Month == Todays.Month && E2.offencedt.Year == Todays.Year && E2.case_stat == true


                            group new { E1, E2 } by new
                            {
                                E1.offence_code,
                                E2.comdid,
                                E1.offence_desc,

                            } into g


                            select new DispAnarep
                            {
                                offence_code = g.Key.offence_code,
                                comdid = g.Key.comdid,
                                offence_desc = g.Key.offence_desc,

                                Total = g.Count(),




                            });

                ViewBag.CasestateminPre = Emp9;


                //action taken Quaterly months




                var Quaterly_action = (from E1 in _context.tbl_Offences
                                       join E2 in _context.processDatas
                                       on E1.offence_code equals E2.occuranceid

                                       //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today3.Month && E2.offencedt.Year == Today3.Year && E2.case_stat == true
                                       where E1.maj_offence == true  && E2.offencedt > DateTime.Now.AddMonths(-3) && E2.case_stat == true

                                       group new { E1, E2 } by new
                                       {
                                           E1.offence_code,
                                           E2.comdid,
                                           E1.offence_desc,

                                       } into g


                                       select new DispAnarep
                                       {
                                           offence_code = g.Key.offence_code,
                                           comdid = g.Key.comdid,
                                           offence_desc = g.Key.offence_desc,

                                           Total = g.Count(),




                                       });

                ViewBag.CasestatemajQuaterly = Quaterly_action;












                var Quaterly_action3 = (from E1 in _context.tbl_Offences
                                        join E2 in _context.processDatas
                                        on E1.offence_code equals E2.occuranceid
                                        //join E3 in _context.mProunit on E2.comdid equals E3.Command
                                        where E1.maj_offence == false  && E2.offencedt > DateTime.Now.AddMonths(-3) && E2.case_stat == true


                                        group new { E1, E2 } by new
                                        {
                                            E1.offence_code,
                                            E2.comdid,
                                            E1.offence_desc,

                                        } into g


                                        select new DispAnarep
                                        {
                                            offence_code = g.Key.offence_code,
                                            comdid = g.Key.comdid,
                                            offence_desc = g.Key.offence_desc,

                                            Total = g.Count(),




                                        });

                ViewBag.CasestateminQuaterly = Quaterly_action3;



                //action taken Half Yearly six months


                var HalfYearly_action = (from E1 in _context.tbl_Offences
                                         join E2 in _context.processDatas
                                         on E1.offence_code equals E2.occuranceid

                                         //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today_Half.Month && E2.offencedt.Year == Today_Half.Year && E2.case_stat == true
                                         where E1.maj_offence == true  && E2.offencedt > DateTime.Now.AddMonths(-6) && E2.case_stat == true

                                         group new { E1, E2 } by new
                                         {
                                             E1.offence_code,
                                             E2.comdid,
                                             E1.offence_desc,

                                         } into g


                                         select new DispAnarep
                                         {
                                             offence_code = g.Key.offence_code,
                                             comdid = g.Key.comdid,
                                             offence_desc = g.Key.offence_desc,

                                             Total = g.Count(),




                                         });

                ViewBag.CasestatemajHalfYearly = HalfYearly_action;





                var HalfYearly_action6 = (from E1 in _context.tbl_Offences
                                          join E2 in _context.processDatas
                                          on E1.offence_code equals E2.occuranceid

                                          //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == Today_Half1.Month && E2.offencedt.Year == Today_Half1.Year && E2.case_stat == true
                                          where E1.maj_offence == false  && E2.offencedt > DateTime.Now.AddMonths(-6) && E2.case_stat == true

                                          group new { E1, E2 } by new
                                          {
                                              E1.offence_code,
                                              E2.comdid,
                                              E1.offence_desc,

                                          } into g


                                          select new DispAnarep
                                          {
                                              offence_code = g.Key.offence_code,
                                              comdid = g.Key.comdid,
                                              offence_desc = g.Key.offence_desc,

                                              Total = g.Count(),




                                          });

                ViewBag.CasestateminHalfYearly = HalfYearly_action6;



                //action taken  Yearly Twelve months




                var Yearly_action = (from E1 in _context.tbl_Offences
                                     join E2 in _context.processDatas
                                     on E1.offence_code equals E2.occuranceid

                                     //where E1.maj_offence == true && E2.comdid == comdids && E2.offencedt.Month == Today_Yearly.Month && E2.offencedt.Year == Today_Yearly.Year && E2.case_stat == true
                                     where E1.maj_offence == true && E2.offencedt > DateTime.Now.AddMonths(-12) && E2.case_stat == true

                                     group new { E1, E2 } by new
                                     {
                                         E1.offence_code,
                                         E2.comdid,
                                         E1.offence_desc,

                                     } into g


                                     select new DispAnarep
                                     {
                                         offence_code = g.Key.offence_code,
                                         comdid = g.Key.comdid,
                                         offence_desc = g.Key.offence_desc,

                                         Total = g.Count(),




                                     });

                ViewBag.CasestatemajYearly = Yearly_action;




                var Yearly_action12 = (from E1 in _context.tbl_Offences
                                       join E2 in _context.processDatas
                                       on E1.offence_code equals E2.occuranceid

                                       //where E1.maj_offence == false && E2.comdid == comdids && E2.offencedt.Month == Today_Yearly1.Month && E2.offencedt.Year == Today_Yearly1.Year && E2.case_stat == true
                                       where E1.maj_offence == false  && E2.offencedt > DateTime.Now.AddMonths(-12) && E2.case_stat == true

                                       group new { E1, E2 } by new
                                       {
                                           E1.offence_code,
                                           E2.comdid,
                                           E1.offence_desc,

                                       } into g


                                       select new DispAnarep
                                       {
                                           offence_code = g.Key.offence_code,
                                           comdid = g.Key.comdid,
                                           offence_desc = g.Key.offence_desc,

                                           Total = g.Count(),




                                       });

                ViewBag.CasestateminYearly = Yearly_action12;


            }




            return View();

        }



































        public IActionResult DiscpAnalysis_PieChart()
        {


            DateTime todays = DateTime.Now;
            //int i = 1;


            var Emp = (from E1 in _context.tbl_Offences
                       join E2 in _context.processDatas
                       on E1.offence_code equals E2.occuranceid

                       //join E3 in _context.mProunit on E2.comdid equals E3.Command
                       where E1.maj_offence == true && E2.offencedt.Month == todays.Month && E2.offencedt.Year == todays.Year && E1.offence_desc == "Fire Case"

                       group new { E1, E2 } by new
                       {
                           E1.offence_code,
                           E2.comdid,
                           E1.offence_desc

                       } into g
                       //select g.Count());


                       select new DispAnarep
                       {


                           Total = g.Count()
                       }).ToList();

            ViewData["FireCase1"] = Emp;



            var FireCase = _context.processDatas.Count(E2 => E2.occuranceid == 17).ToString();


            ViewData["FireCase"] = FireCase;


            var MtAccident = _context.processDatas.Count(E2 => E2.occuranceid == 16).ToString();


            ViewData["MtAccident"] = MtAccident;



            var Death = _context.processDatas.Count(E2 => E2.occuranceid == 15).ToString();


            ViewData["Death"] = Death;


            var Drugging = _context.processDatas.Count(E2 => E2.occuranceid == 20).ToString();


            ViewData["Drugging"] = Drugging;


            var Rape = _context.processDatas.Count(E2 => E2.occuranceid == 14).ToString();


            ViewData["RTA"] = Rape;





            return View();

        }


    }
}



