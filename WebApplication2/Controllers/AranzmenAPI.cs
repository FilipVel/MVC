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
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AranzmenAPI : ApiController
    {
        private Context db = new Context();

        // GET: api/Aranzmen
        public IQueryable<Aranzman> GetAranzmani()
        {
            return db.Aranzmani;
        }

        // GET: api/Aranzmen/5
        [ResponseType(typeof(Aranzman))]
        public IHttpActionResult GetAranzman(int id)
        {
            Aranzman aranzman = db.Aranzmani.Find(id);
            if (aranzman == null)
            {
                return NotFound();
            }

            return Ok(aranzman);
        }

        // PUT: api/Aranzmen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAranzman(int id, Aranzman aranzman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aranzman.Id)
            {
                return BadRequest();
            }

            db.Entry(aranzman).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AranzmanExists(id))
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

        // POST: api/Aranzmen
        [ResponseType(typeof(Aranzman))]
        public IHttpActionResult PostAranzman(Aranzman aranzman)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Aranzmani.Add(aranzman);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aranzman.Id }, aranzman);
        }

        // DELETE: api/Aranzmen/5
        [ResponseType(typeof(Aranzman))]
        public IHttpActionResult DeleteAranzman(int id)
        {
            Aranzman aranzman = db.Aranzmani.Find(id);
            if (aranzman == null)
            {
                return NotFound();
            }

            db.Aranzmani.Remove(aranzman);
            db.SaveChanges();

            return Ok(aranzman);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AranzmanExists(int id)
        {
            return db.Aranzmani.Count(e => e.Id == id) > 0;
        }
    }
}