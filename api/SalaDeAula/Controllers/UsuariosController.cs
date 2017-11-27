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
    public class UsuariosController : ApiController
    {
        private SalaDeAulaEntities db = new SalaDeAulaEntities();

        // GET: api/usuarios
        /// <summary>
        /// Retornar todos os usuarios cadastrados.
        /// </summary>
        /// <returns></returns>
        public IQueryable<usuario> GetUsuario()
        {
            db.Configuration.LazyLoadingEnabled = false;

            return db.usuario;
        }

        // GET: api/usuarios/5
        [ResponseType(typeof(usuario))]
        public IHttpActionResult GetUsuario(long id)
        {
            db.Configuration.LazyLoadingEnabled = false;

            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(long id, usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.codigo_usuario)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!usuarioExists(id))
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

        // POST: api/usuarios
        [ResponseType(typeof(usuario))]
        public IHttpActionResult PostUsuario(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.usuario.Add(usuario);
            db.SaveChanges();

            return CreatedAtRoute("Default", new { id = usuario.codigo_usuario }, usuario);
        }

        // DELETE: api/usuarios/5
        [ResponseType(typeof(usuario))]
        public IHttpActionResult DeleteUsuario(long id)
        {
            usuario usuario = db.usuario.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.usuario.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool usuarioExists(long id)
        {
            return db.usuario.Count(e => e.codigo_usuario == id) > 0;
        }
    }
}