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
    public class BoardsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Boards
        public IQueryable<Boards> GetBoards()
        {
            return db.Boards;
        }

        // GET: api/Boards/5
        [ResponseType(typeof(Boards))]
        public IHttpActionResult GetBoards(int id)
        {
            Boards boards = db.Boards.Find(id);
            if (boards == null)
            {
                return NotFound();
            }

            return Ok(boards);
        }

        // PUT: api/Boards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBoards(int id, Boards boards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != boards.ID)
            {
                return BadRequest();
            }

            db.Entry(boards).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoardsExists(id))
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

        // POST: api/Boards
        [ResponseType(typeof(Boards))]
        public IHttpActionResult PostBoards(Boards boards)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Boards.Add(boards);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = boards.ID }, boards);
        }

        // DELETE: api/Boards/5
        [ResponseType(typeof(Boards))]
        public IHttpActionResult DeleteBoards(int id)
        {
            Boards boards = db.Boards.Find(id);
            if (boards == null)
            {
                return NotFound();
            }

            db.Boards.Remove(boards);
            db.SaveChanges();

            return Ok(boards);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BoardsExists(int id)
        {
            return db.Boards.Count(e => e.ID == id) > 0;
        }
    }
}