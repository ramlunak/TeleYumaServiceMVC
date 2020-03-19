using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TeleYumaServiceMVC.Models;

namespace TeleYumaServiceMVC.Controllers
{
    public class DingPromoController : ApiController
    {
        private TeleYumaEntities1 db = new TeleYumaEntities1();

        // GET: api/DingPromo
        public DingPromo GetDingPromo()
        {

            try
            {
                return db.DingPromo.First(x => x.Estado == true);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET: api/DingPromo/5
        [ResponseType(typeof(DingPromo))]
        public async Task<IHttpActionResult> GetDingPromo(int id)
        {
            DingPromo dingPromo = await db.DingPromo.FindAsync(id);
            if (dingPromo == null)
            {
                return NotFound();
            }

            return Ok(dingPromo);
        }

        // PUT: api/DingPromo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDingPromo(int id, DingPromo dingPromo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dingPromo.Id)
            {
                return BadRequest();
            }

            db.Entry(dingPromo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DingPromoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DingPromo
        [ResponseType(typeof(DingPromo))]
        public async Task<IHttpActionResult> PostDingPromo(DingPromo dingPromo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DingPromo.Add(dingPromo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dingPromo.Id }, dingPromo);
        }

        // DELETE: api/DingPromo/5
        [ResponseType(typeof(DingPromo))]
        public async Task<IHttpActionResult> DeleteDingPromo(int id)
        {
            DingPromo dingPromo = await db.DingPromo.FindAsync(id);
            if (dingPromo == null)
            {
                return NotFound();
            }

            db.DingPromo.Remove(dingPromo);
            await db.SaveChangesAsync();

            return Ok(dingPromo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DingPromoExists(int id)
        {
            return db.DingPromo.Count(e => e.Id == id) > 0;
        }
    }
}