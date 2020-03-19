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

namespace TeleYumaServiceMVC.Areas.Admin.Controllers
{
    public class DingPromoController : Controller
    {
        private teleyumaEntities1 db = new teleyumaEntities1();

        // GET: Admin/DingPromo
        public async Task<ActionResult> Index()
        {
            return View(await db.DingPromo.ToListAsync());
        }

        // GET: Admin/DingPromo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DingPromo dingPromo = await db.DingPromo.FindAsync(id);
            if (dingPromo == null)
            {
                return HttpNotFound();
            }
            return View(dingPromo);
        }

        // GET: Admin/DingPromo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DingPromo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProviderCode,StartUtc,EndUtc,Promo,Min,Max,MontoText,Estado")] DingPromo dingPromo)
        {
            if (ModelState.IsValid)
            {
                db.DingPromo.Add(dingPromo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dingPromo);
        }

        // GET: Admin/DingPromo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DingPromo dingPromo = await db.DingPromo.FindAsync(id);
            if (dingPromo == null)
            {
                return HttpNotFound();
            }
            return View(dingPromo);
        }

        // POST: Admin/DingPromo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProviderCode,StartUtc,EndUtc,Promo,Min,Max,MontoText,Estado")] DingPromo dingPromo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dingPromo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dingPromo);
        }

        // GET: Admin/DingPromo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DingPromo dingPromo = await db.DingPromo.FindAsync(id);
            if (dingPromo == null)
            {
                return HttpNotFound();
            }
            return View(dingPromo);
        }

        // POST: Admin/DingPromo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DingPromo dingPromo = await db.DingPromo.FindAsync(id);
            db.DingPromo.Remove(dingPromo);
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
