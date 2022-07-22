using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCRS1.Data;
using MPCRS1.Models;
using System.Diagnostics;


namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]                                      //for rendering first page of login  first then the home or index page 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private dynamic count1;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            var dashboard = from E1 in _context.processDatas
                            where E1 != null && E1.case_stat==true select E1;

            int count =  dashboard.Count();
            ViewBag.Count = count;

            var dashboard1 = from E1 in _context.processDatas
                            where E1 != null && E1.case_stat == false   select E1;
                          

            int aj = dashboard1.Count();
            ViewBag.Count1 = aj;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}