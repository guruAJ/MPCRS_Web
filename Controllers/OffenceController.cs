using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPCRS1.Data;
using MPCRS1.Models;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class OffenceController : Controller
    {
        private readonly ApplicationDbContext _db;                   //creating object of dbcontext class

        public OffenceController(ApplicationDbContext db)            //creating object of controller by making constructor
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.tbl_Offences.ToListAsync());
        }


      public async Task<IActionResult>Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(tbl_offence offence)
        {
           
            _db.tbl_Offences.Add(offence);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Edit(int? Id )
        {
            if (Id == null)
            {
                return NotFound();
            }

            var offence = await _db.tbl_Offences.FindAsync(Id);
            if (offence == null)
            {
                return NotFound();
            }
     
            //return RedirectToAction("ProcessDataCnf", "ProcessData");
            return View(offence);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int offnsid , [Bind("offnsid,offence_code,offence_desc,maj_offence,Print_seq")] tbl_offence _Offence)
        {
            if (offnsid != _Offence.offnsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(_Offence);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbl_offenceExists(_Offence.offnsid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_Offence);
        }

        private bool tbl_offenceExists(int offnsid)
        {
            return  _db.tbl_Offences.Any(e => e.offnsid == offnsid ); 
        }

      
    }
}
