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
using ToDoModel;
using System.Web.Http.Cors;
using ToDoWebApi.Models;


namespace ToDoWebApi.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ToDoEventsController : ApiController
    {
        private ToDoContext db = new ToDoContext();

        // GET: api/ToDoEvents
        [Route("api/todos/{todoId}/events")]
        public IEnumerable<ToDoEventVM> GetToDoEventsByTodo(int todoId)
        {

            var retval = db.ToDoEvents.Where(t => t.ToDoId == todoId).Select(i=> 
                new ToDoEventVM { Title = i.ToDo.Title, Comment = i.Comment, Rating = i.Rating, TodoId = i.ToDo.ToDoId, OccurredDttm = i.OccurredDttm });
            // var retval = db.ToDoEvents.ToList();
            return retval;
        }

        [Route("api/todos/{todoId}/event")]
        [HttpPost]
        // POST: api/ToDoEvents
        [ResponseType(typeof(ToDoEventVM))]
        public async Task<IHttpActionResult> PostToDoEvent(ToDoEventVM toDoEventVM)
        {
            if (toDoEventVM.OccurredDttm == null || toDoEventVM.OccurredDttm.Ticks == 0)
            {
                toDoEventVM.OccurredDttm = DateTime.Now;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ToDoEvent newToDoEvent = new ToDoEvent { ToDoId = toDoEventVM.TodoId, Comment = toDoEventVM.Comment, Rating = toDoEventVM.Rating, OccurredDttm = toDoEventVM.OccurredDttm };

            db.ToDoEvents.Add(newToDoEvent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { controller = "ToDoEventsController", id = newToDoEvent.ToDoEventId }, newToDoEvent);
        }


        // GET: api/ToDoEvents/5
        [ResponseType(typeof(ToDoEvent))]
        public async Task<IHttpActionResult> GetToDoEvent(int id)
        {
            ToDoEvent toDoEvent = await db.ToDoEvents.FindAsync(id);
            if (toDoEvent == null)
            {
                return NotFound();
            }

            return Ok(toDoEvent);
        }

        // PUT: api/ToDoEvents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutToDoEvent(int id, ToDoEvent toDoEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoEvent.ToDoEventId)
            {
                return BadRequest();
            }

            db.Entry(toDoEvent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoEventExists(id))
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


        // DELETE: api/ToDoEvents/5
        [ResponseType(typeof(ToDoEvent))]
        public async Task<IHttpActionResult> DeleteToDoEvent(int id)
        {
            ToDoEvent toDoEvent = await db.ToDoEvents.FindAsync(id);
            if (toDoEvent == null)
            {
                return NotFound();
            }

            db.ToDoEvents.Remove(toDoEvent);
            await db.SaveChangesAsync();

            return Ok(toDoEvent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoEventExists(int id)
        {
            return db.ToDoEvents.Count(e => e.ToDoEventId == id) > 0;
        }
    }
}