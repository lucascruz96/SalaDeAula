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
    public class AtividadesController : ApiController
    {
        private SalaDeAulaEntities db = new SalaDeAulaEntities();

        // GET: api/atividades
        public IQueryable<atividade> Getatividade()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return db.atividade;
        }

        // GET: api/atividades/5
        [ResponseType(typeof(atividade))]
        public IHttpActionResult GetAtividade(long id)
        {
            db.Configuration.LazyLoadingEnabled = false;

            atividade atividade = db.atividade.Find(id);
            if (atividade == null)
            {
                return NotFound();
            }

            return Ok(atividade);
        }

        // PUT: api/atividades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtividade(long id, atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atividade.codigo_atividade)
            {
                return BadRequest();
            }

            db.Entry(atividade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!atividadeExists(id))
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

        // POST: api/atividades
        [ResponseType(typeof(atividade))]
        public IHttpActionResult PostAtividade(atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.atividade.Add(atividade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = atividade.codigo_atividade }, atividade);
        }

        // DELETE: api/atividades/5
        [ResponseType(typeof(atividade))]
        public IHttpActionResult DeleteAtividade(long id)
        {
            atividade atividade = db.atividade.Find(id);
            if (atividade == null)
            {
                return NotFound();
            }

            db.atividade.Remove(atividade);
            db.SaveChanges();

            return Ok(atividade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool atividadeExists(long id)
        {
            return db.atividade.Count(e => e.codigo_atividade == id) > 0;
        }
    }
}