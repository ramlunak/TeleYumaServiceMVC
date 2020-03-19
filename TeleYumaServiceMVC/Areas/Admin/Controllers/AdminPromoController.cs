using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeleYumaServiceMVC.Models;
using System.IO;

namespace TeleYumaServiceMVC.Areas.Admin.Controllers
{
    public class AdminPromoController : Controller
    {
        private teleyumaEntities1 db = new teleyumaEntities1();

        // GET: Admin/AdminPromo
        public async Task<ActionResult> Index()
        {
            return View(await db.Promo.ToListAsync());
        }

        // GET: Admin/AdminPromo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        // GET: Admin/AdminPromo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminPromo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create(HttpPostedFileBase file)
        {

            var length = file.InputStream.Length; //Length: 103050706
            MemoryStream target = new MemoryStream();
            file.InputStream.CopyTo(target); // generates problem in this line
            byte[] data = target.ToArray();
            

            db.Promo.Add(new Promo { image = data });
            await db.SaveChangesAsync();
            return RedirectToAction("Index");



        }

        // GET: Admin/AdminPromo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        // POST: Admin/AdminPromo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,image")] Promo promo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(promo);
        }

        // GET: Admin/AdminPromo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return HttpNotFound();
            }
            return View(promo);
        }

        // POST: Admin/AdminPromo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Promo promo = await db.Promo.FindAsync(id);
            db.Promo.Remove(promo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
