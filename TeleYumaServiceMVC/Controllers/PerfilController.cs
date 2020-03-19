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
    public class PerfilController : ApiController
    {
        private teleyumaEntities1 db = new teleyumaEntities1();

        // GET: api/Perfil
        public async Task<IHttpActionResult> GetPerfil()
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            return CreatedAtRoute("DefaultApi", null, db.Perfil);
        }

        // GET: api/Perfil/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> GetPerfil([FromUri] string id)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));

            try
            {
                var perfil = db.Perfil.ToList().Where(x => x.IdCuenta == id).Last();
                return Ok(perfil);
            }
            catch (Exception ex)
            {

                return Ok(new Perfil());

            }


        }

        // PUT: api/Perfil/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerfil([FromUri] int id, [FromUri] Perfil perfil)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));


            if (id != perfil.Id)
            {
                return BadRequest();
            }

            db.Entry(perfil).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfil
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> PostPerfil([FromUri]Perfil perfil)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));
            var exist = db.Perfil.ToList().Where(x => x.IdCuenta == perfil.IdCuenta);

            if(perfil.Foto is null) return CreatedAtRoute("DefaultApi", null, perfil );

            if (exist.Any())
            {
                var f = exist.First();
                f.Foto = perfil.Foto;

                db.Entry(f).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = f.Id }, f);
            }
            else
            {
                db.Perfil.Add(perfil);
                await db.SaveChangesAsync();

                return CreatedAtRoute("DefaultApi", new { id = perfil.Id }, perfil);
            }

          
        }

        // DELETE: api/Perfil/5
        [ResponseType(typeof(Perfil))]
        public async Task<IHttpActionResult> DeletePerfil([FromUri]int id)
        {
            if (Autorize.TeleyumaLogin(this.Request.Headers).ErrorCode > 0)
                return CreatedAtRoute("DefaultApi", null, Autorize.TeleyumaLogin(this.Request.Headers));


            Perfil perfil = await db.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }

            db.Perfil.Remove(perfil);
            await db.SaveChangesAsync();

            return Ok(perfil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PerfilExists(int id)
        {
            return db.Perfil.Count(e => e.Id == id) > 0;
        }
    }
}