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
    public class CredencialesController : ApiController
    {
        private teleyumaEntities1 db = new teleyumaEntities1();

        // GET: api/Credenciales
        public IQueryable<Credenciales> GetCredenciales()
        {

            return db.Credenciales;

        }

        // GET: api/Credenciales/5
        [ResponseType(typeof(Credenciales))]
        public async Task<IHttpActionResult> GetCredenciales(int id)
        {
            Credenciales credenciales = await db.Credenciales.FindAsync(id);
            if (credenciales == null)
            {
                return NotFound();
            }

            return Ok(credenciales);
        }

        // PUT: api/Credenciales/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCredenciales(int id, Credenciales credenciales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != credenciales.Id)
            {
                return BadRequest();
            }

            db.Entry(credenciales).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredencialesExists(id))
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

        // POST: api/Credenciales
        [ResponseType(typeof(Credenciales))]
        public async Task<IHttpActionResult> PostCredenciales(Credenciales credenciales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Credenciales.Add(credenciales);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = credenciales.Id }, credenciales);
        }

        // DELETE: api/Credenciales/5
        [ResponseType(typeof(Credenciales))]
        public async Task<IHttpActionResult> DeleteCredenciales(int id)
        {
            Credenciales credenciales = await db.Credenciales.FindAsync(id);
            if (credenciales == null)
            {
                return NotFound();
            }

            db.Credenciales.Remove(credenciales);
            await db.SaveChangesAsync();

            return Ok(credenciales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CredencialesExists(int id)
        {
            return db.Credenciales.Count(e => e.Id == id) > 0;
        }
    }
}