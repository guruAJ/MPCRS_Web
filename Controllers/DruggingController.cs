using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCRS1.Data;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DruggingController : Controller
    {
        public readonly ApplicationDbContext _context;

        public DruggingController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 



            var drugging  = from a1  in _context.processDatas
                              where  a1.occurance_offence == "Druggings"  || a1.occuranceid == 20

                            select a1;


            //var drugging = (from E1 in _context.processDatas
                           //join E2 in _context.tbl_Offences
                           //on E1.occuranceid equals E2.offence_code
                           //where E2.offence_code == 20 group E2 by E2.offence_code into g select g).ToList();
            //var drugging = _context.processDatas.ToList();
            return View(drugging);
           
        }
    }
}
