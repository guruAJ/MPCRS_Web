using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCRS1.Data;
using MPCRS1.Models;
namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class MTAccidentController : Controller
    {
        public readonly ApplicationDbContext _context;

        public MTAccidentController (ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var MTaccident  = from a1 in _context.processDatas

                              where a1.occurance_offence == "MT Accident" || a1.occuranceid == 16
                              
                              select a1;

            //var MTaccident = _context.processDatas.ToList();
            return View(MTaccident);
        }
    }
}
