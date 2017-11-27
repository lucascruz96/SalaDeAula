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
    public class RespostasController : ApiController
    {
        private SalaDeAulaEntities db = new SalaDeAulaEntities();

        // GET: api/respostas
        public IQueryable<resposta> GetResposta()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return db.resposta;
        }

        // GET: api/respostas/5
        [ResponseType(typeof(resposta))]
        public IHttpActionResult GetResposta(long id)
        {
            db.Configuration.LazyLoadingEnabled = false;

            resposta resposta = db.resposta.Find(id);
            if (resposta == null)
            {
                return NotFound();
            }

            return Ok(resposta);
        }

        // PUT: api/respostas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResposta(long id, resposta resposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resposta.codigo_resposta)
            {
                return BadRequest();
            }

            db.Entry(resposta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!respostaExists(id))
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

        // POST: api/respostas
        [ResponseType(typeof(resposta))]
        public IHttpActionResult PostResposta(resposta resposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.resposta.Add(resposta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resposta.codigo_resposta }, resposta);
        }

        // DELETE: api/respostas/5
        [ResponseType(typeof(resposta))]
        public IHttpActionResult DeleteResposta(long id)
        {
            resposta resposta = db.resposta.Find(id);
            if (resposta == null)
            {
                return NotFound();
            }

            db.resposta.Remove(resposta);
            db.SaveChanges();

            return Ok(resposta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool respostaExists(long id)
        {
            return db.resposta.Count(e => e.codigo_resposta == id) > 0;
        }
    }
}