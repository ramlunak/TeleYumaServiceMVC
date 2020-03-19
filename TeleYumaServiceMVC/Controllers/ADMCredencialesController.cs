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
using TeleYumaServiceMVC.Class;

namespace TeleYumaServiceMVC.Controllers
{
    public class ADMCredencialesController : Controller
    {
        private teleyumaEntities1 db = new teleyumaEntities1();

        // GET: ADMCredenciales
        public async Task<ActionResult> Index()
        {
            return View(await db.Credenciales.ToListAsync());
        }

        
        // GET: ADMCredenciales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMCredenciales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Proveedor,KeyName,KeyValue")] Credenciales credenciales)
        {
            if (ModelState.IsValid)
            {
                credenciales.KeyValue = credenciales.KeyValue.Encrypt();
                db.Credenciales.Add(credenciales);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(credenciales);
        }

        // GET: ADMCredenciales/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credenciales credenciales = await db.Credenciales.FindAsync(id);
            if (credenciales == null)
            {
                return HttpNotFound();
            }
            return View(credenciales);
        }

        // POST: ADMCredenciales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Proveedor,KeyName,KeyValue")] Credenciales credenciales)
        {
            if (ModelState.IsValid)
            {
                credenciales.KeyValue = credenciales.KeyValue.Encrypt();
                db.Entry(credenciales).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(credenciales);
        }

        // GET: ADMCredenciales/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Credenciales credenciales = await db.Credenciales.FindAsync(id);
            if (credenciales == null)
            {
                return HttpNotFound();
            }
            return View(credenciales);
        }

        // POST: ADMCredenciales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Credenciales credenciales = await db.Credenciales.FindAsync(id);
            db.Credenciales.Remove(credenciales);
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
