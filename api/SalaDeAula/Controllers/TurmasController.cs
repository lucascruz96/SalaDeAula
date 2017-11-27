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
    public class TurmasController : ApiController
    {
        private SalaDeAulaEntities db = new SalaDeAulaEntities();

        // GET: api/turmas
        public IQueryable<turma> GetTurma()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return db.turma;
        }

        // GET: api/turmas/5
        [ResponseType(typeof(turma))]
        public IHttpActionResult GetTurma(long id)
        {
            db.Configuration.LazyLoadingEnabled = false;

            turma turma = db.turma.Find(id);
            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma);
        }

        // PUT: api/turmas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTurma(long id, turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turma.codigo_turma)
            {
                return BadRequest();
            }

            db.Entry(turma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!turmaExists(id))
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

        // POST: api/turmas
        [ResponseType(typeof(turma))]
        public IHttpActionResult PostTurma(turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.turma.Add(turma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = turma.codigo_turma }, turma);
        }

        // DELETE: api/turmas/5
        [ResponseType(typeof(turma))]
        public IHttpActionResult DeleteTurma(long id)
        {
            turma turma = db.turma.Find(id);
            if (turma == null)
            {
                return NotFound();
            }

            db.turma.Remove(turma);
            db.SaveChanges();

            return Ok(turma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool turmaExists(long id)
        {
            return db.turma.Count(e => e.codigo_turma == id) > 0;
        }
    }
}