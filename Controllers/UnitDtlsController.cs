using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MPCRS1.Data;
using MPCRS1.Models;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class UnitDtlsController : Controller
    {

        private readonly ApplicationDbContext _context;


        public UnitDtlsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitDtls
        public async Task<IActionResult> Index()
        {
            var list = (from a in _context.mProunit
                        join b in _context.tbl_Comds
                        on a.Command equals b.comdid

                        select new UnitDtl
                        {
                            Id=a.Id,
                            UnitName=a.UnitName,    
                            Command=a.Command,
                            UnitCode=a.UnitCode,
                            Location=a.Location,
                            Fmn=a.Fmn,
                            Status=a.Status,
                            UpdatedBy=a.UpdatedBy,
                            UpdatedDate=a.UpdatedDate,
                            CommandName=b.Command
                        }
                        ).ToList();

                    
            return View(list);
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unitDtl = await _context.mProunit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unitDtl == null)
            {
                return NotFound();
            }

            return View(unitDtl);
        }

        // GET: UnitDtls/Create
        public IActionResult Create()
        {
            List<tbl_Comd> cl = new List<tbl_Comd>();
            cl = (from c in _context.tbl_Comds select c).ToList();
            cl.Insert(0, new tbl_Comd { comdid = 0, Command = "--Select Command Name--" });
            ViewBag.cl = cl.ToList();
           

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UnitName,UnitCode,Location,Fmn,Command,Status,UpdatedBy,UpdatedDate")] UnitDtl unitDtl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unitDtl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unitDtl);
        }

        // GET: UnitDtls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<tbl_Comd> cl = new List<tbl_Comd>();
            cl = (from c in _context.tbl_Comds select c).ToList();
            cl.Insert(0, new tbl_Comd { comdid = 0, Command = "--Select Command Name--" });
            ViewBag.cl = cl.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var unitDtl = await _context.mProunit.FindAsync(id);
            if (unitDtl == null)
            {
                return NotFound();
            }
            var s = unitDtl.UnitName;

            TempData["mydata"] = s;

            return View(unitDtl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UnitName,UnitCode,Location,Fmn,Command,Status,UpdatedBy,UpdatedDate")] UnitDtl unitDtl)
        {
            if (id != unitDtl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unitDtl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitDtlExists(unitDtl.Id))
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
            return View(unitDtl);
        }

        // GET: UnitDtls/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var unitDtl = await _context.mProunit
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (unitDtl == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(unitDtl);
        //}

        //// POST: UnitDtls/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var unitDtl = await _context.mProunit.FindAsync(id);
        //    _context.mProunit.Remove(unitDtl);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool UnitDtlExists(int id)
        {
            return _context.mProunit.Any(e => e.Id == id);
        }



        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var unitDtl = await _context.mProunit.FindAsync(id);
            _context.mProunit.Remove(unitDtl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}

