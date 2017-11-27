using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SalaDeAula.Models;

namespace SalaDeAula.Controllers
{
    public class MensagensController : ApiController
    {
        private SalaDeAulaEntities db = new SalaDeAulaEntities();

        // GET: api/mensagems
        public IQueryable<mensagem> Getmensagem()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return db.mensagem;
        }

        // GET: api/mensagems/5
        [ResponseType(typeof(mensagem))]
        public IHttpActionResult GetMensagem(long id)
        {
            db.Configuration.LazyLoadingEnabled = false;

            mensagem mensagem = db.mensagem.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return Ok(mensagem);
        }

        // PUT: api/mensagems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMensagem(long id, mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensagem.codigo_mensagem)
            {
                return BadRequest();
            }

            db.Entry(mensagem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!mensagemExists(id))
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

        // POST: api/mensagems
        [ResponseType(typeof(mensagem))]
        public IHttpActionResult PostMensagem(mensagem mensagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.mensagem.Add(mensagem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mensagem.codigo_mensagem }, mensagem);
        }

        // DELETE: api/mensagems/5
        [ResponseType(typeof(mensagem))]
        public IHttpActionResult Deletemensagem(long id)
        {
            mensagem mensagem = db.mensagem.Find(id);
            if (mensagem == null)
            {
                return NotFound();
            }

            db.mensagem.Remove(mensagem);
            db.SaveChanges();

            return Ok(mensagem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mensagemExists(long id)
        {
            return db.mensagem.Count(e => e.codigo_mensagem == id) > 0;
        }
    }
}