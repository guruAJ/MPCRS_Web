using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCRS1.Data;
using MPCRS1.Models;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context= context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: UnitDtls/Create
   

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index ([Bind("Id,Name,Email,Message")] Contact contact )
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }
    }
}
