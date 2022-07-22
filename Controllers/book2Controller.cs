﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MPCRS1.Controllers
{
    [Authorize]

    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class book2Controller : Controller
    {
        // GET: book2Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: book2Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: book2Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: book2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: book2Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: book2Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: book2Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: book2Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
