using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeleYumaServiceMVC.Controllers
{
    public class AutorizeController : Controller
    {
        // GET: Autorize
        public ActionResult Index()
        {
            return View();
        }

        // GET: Autorize/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Autorize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autorize/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autorize/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Autorize/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autorize/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Autorize/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
