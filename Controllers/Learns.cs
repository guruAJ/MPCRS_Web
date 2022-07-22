using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MPCRS1.Data;
//using MPCRS1.Helpers;
using MPCRS1.Models;

namespace MPCRS1.Controllers
{
    public class Learns : Controller
    {
  

        public readonly ApplicationDbContext _context = null;
        public IActionResult Index(int Id)
        {
            Login Model = new Login();
            if (Id != 0)
            {
                Model = _context.logins.Where(i => i.Id == Id).Single();
            }

            var AllUser = _context.logins.Where(i => i.IsActive == 1).ToList();

            ViewBag.Name = AllUser;


            return View(Model);

        }
        public IActionResult List()
        {
            Login model = new Login();
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(Login Db)
        {
            
            if (ModelState.IsValid)
            {
                Db.IsActive = 1;
                Db.CreatedOn = DateTime.Now;
                Db.UpdatedOn = DateTime.Now;
                //Db.CreatedBy = Logins.Id;

                if (Db.Id == 0)
                {
                    _context.Add(Db);
                    _context.SaveChanges();
                    ViewBag.message = "The user " + Db.Name + " is saved successfully";
                }
                else
                {
                    _context.Update(Db);
                    await _context.SaveChangesAsync();
                    ViewBag.message = "The user " + Db.Name + " is Update successfully";
                }


                var AllUser1 = _context.logins.Where(i => i.IsActive == 1).ToList();

                ViewBag.Name = AllUser1;
                return View("Index", Db);

            }
            else
            {
                return View("Index", Db);
            }
        }

        public async Task<IActionResult> Delete(Login Db)
        {
            //Login Logins = SessionHelper.GetObjectFromJson<Login>(HttpContext.Session, "User");

            Db = _context.logins.Where(i => i.Id == Db.Id).Single();

            Db.IsActive = 0;
            Db.UpdatedOn = DateTime.Now;

            _context.Update(Db);
            await _context.SaveChangesAsync();
            ViewBag.messageDelete = "The user " + Db.Name + " is Delete successfully";

            var AllUser1 = _context.logins.Where(i => i.Id == Db.Id).ToList();

            ViewBag.Name = AllUser1;
            return RedirectToAction("Index");



        }
    }
}
