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
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class CentersController : ApiController
    {
        private CenterBookingEntities2 db = new CenterBookingEntities2();

        // GET: api/Centers
        public IQueryable<Center> GetCenters()
        {
            return db.Centers;
        }

        // GET: api/Centers/5
        [ResponseType(typeof(Center))]
        public IHttpActionResult GetCenter(int id)
        {
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return NotFound();
            }

            return Ok(center);
        }

        // PUT: api/Centers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCenter(int id, Center center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != center.Id)
            {
                return BadRequest();
            }

            db.Entry(center).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterExists(id))
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

        // POST: api/Centers
        [ResponseType(typeof(Center))]
        public IHttpActionResult PostCenter(Center center)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Centers.Add(center);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = center.Id }, center);
        }

        // DELETE: api/Centers/5
        [ResponseType(typeof(Center))]
        public IHttpActionResult DeleteCenter(int id)
        {
            Center center = db.Centers.Find(id);
            if (center == null)
            {
                return NotFound();
            }

            db.Centers.Remove(center);
            db.SaveChanges();

            return Ok(center);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CenterExists(int id)
        {
            return db.Centers.Count(e => e.Id == id) > 0;
        }
    }
}