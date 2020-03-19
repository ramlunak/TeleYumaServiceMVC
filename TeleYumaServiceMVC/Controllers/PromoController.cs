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
    public class PromoController : ApiController
    {
        private teleyumaEntities1 db = new teleyumaEntities1();

        // GET: api/Promo
        public async Task<IHttpActionResult> GetPromo()
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            return CreatedAtRoute("DefaultApi", null, db.Promo);
        }

        // GET: api/Promo/5
        [ResponseType(typeof(Promo))]
        public async Task<IHttpActionResult> GetPromo( [FromUri] int id)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }

            return Ok(promo);
        }

        // PUT: api/Promo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPromo( [FromUri] int id, [FromUri] Promo promo)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            if (id != promo.Id)
            {
                return BadRequest();
            }

            db.Entry(promo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromoExists(id))
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

        // POST: api/Promo
        [ResponseType(typeof(Promo))]
        public async Task<IHttpActionResult> PostPromo( [FromUri] Promo promo)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            db.Promo.Add(promo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = promo.Id }, promo);
        }

        // DELETE: api/Promo/5
        [ResponseType(typeof(Promo))]
        public async Task<IHttpActionResult> DeletePromo( [FromUri] int id)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            Promo promo = await db.Promo.FindAsync(id);
            if (promo == null)
            {
                return NotFound();
            }

            db.Promo.Remove(promo);
            await db.SaveChangesAsync();

            return Ok(promo);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromoExists(int id)
        {
            return db.Promo.Count(e => e.Id == id) > 0;
        }
    }
}