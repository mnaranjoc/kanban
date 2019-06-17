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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ColumnsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Columns
        public IQueryable<Columns> GetColumns()
        {
            return db.Columns;
        }

        // GET: api/Columns/5
        [ResponseType(typeof(Columns))]
        public IHttpActionResult GetColumns(int id)
        {
            Columns columns = db.Columns.Find(id);
            if (columns == null)
            {
                return NotFound();
            }

            return Ok(columns);
        }

        // PUT: api/Columns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColumns(int id, Columns columns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != columns.ID)
            {
                return BadRequest();
            }

            db.Entry(columns).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnsExists(id))
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

        // POST: api/Columns
        [ResponseType(typeof(Columns))]
        public IHttpActionResult PostColumns(Columns columns)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Columns.Add(columns);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = columns.ID }, columns);
        }

        // DELETE: api/Columns/5
        [ResponseType(typeof(Columns))]
        public IHttpActionResult DeleteColumns(int id)
        {
            Columns columns = db.Columns.Find(id);
            if (columns == null)
            {
                return NotFound();
            }

            db.Columns.Remove(columns);
            db.SaveChanges();

            return Ok(columns);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColumnsExists(int id)
        {
            return db.Columns.Count(e => e.ID == id) > 0;
        }
    }
}