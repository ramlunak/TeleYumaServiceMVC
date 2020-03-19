using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;

using TeleYumaServiceMVC.Models;

namespace TeleYumaServiceMVC.Controllers
{
    public class SMSController : ApiController
    {

        
        private teleyumaEntities1 db = new teleyumaEntities1();
       

        // GET: api/SMS
        public async Task<IHttpActionResult> GetSMS()
        {            
            if(Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
            return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));
          
            return CreatedAtRoute("DefaultApi", null, db.SMS);

        }

        // GET: api/SMS/5
        [ResponseType(typeof(SMS))]
        public async Task<IHttpActionResult> GetSMS([FromUri] string id)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));
           
                try
            {
                var sms = db.SMS.ToList().Where(x => x.Phone1 == id);
                return Ok(sms);
            }
            catch (Exception ex)
            {

                return Ok(new SMS());

            }

        }

        // PUT: api/SMS/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSMS(int id, [FromUri] SMS sMS)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));
            

           if (id != sMS.Idsms)
            {
                return BadRequest();
            }

            db.Entry(sMS).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMSExists(id))
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

       
        // POST: api/SMS
        [ResponseType(typeof(SMS))]
        public async Task<IHttpActionResult> PostSMS([FromUri] SMS sMS)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));


            db.SMS.Add(sMS);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sMS.Idsms }, sMS);
        }

        // DELETE: api/SMS/5
        [ResponseType(typeof(SMS))]
        public async Task<IHttpActionResult> DeleteSMS( [FromUri] int id)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));


            SMS sMS = await db.SMS.FindAsync(id);
            if (sMS == null)
            {
                return NotFound();
            }

            db.SMS.Remove(sMS);
            await db.SaveChangesAsync();

            return Ok(sMS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SMSExists(int id)
        {
            return db.SMS.Count(e => e.Idsms == id) > 0;
        }

    }
}