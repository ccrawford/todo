using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoModel;
using System.Data.Entity;
using ToDoWebApi.Models;
using System.Web.Http.Cors;


namespace ToDoWebApi.Controllers
{
    
    // [AllowCrossSiteJson]
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ToDosController : ApiController
    {
        public IEnumerable<ToDoListVM> GetAllTodos()
        {
            var context = new ToDoContext();
            // using (var context = new ToDoContext())
            {
                var items = context.ToDos.Where(c => c.User.UserName == "ccrawford").Select(i =>
                        new ToDoListVM { ToDoId=i.ToDoId, 
                            UserName = i.User.UserName, 
                            Title = i.Title, 
                            Description = i.Description, 
                            LastCompleted = i.ToDoEvents.OrderByDescending(j=>j.OccurredDttm).Select(k=>k.OccurredDttm).FirstOrDefault()});

                return items;
            }
        }

        public IHttpActionResult GetTodo(int id)
        {
           
            var context = new ToDoContext();
            // using (var context = new ToDoContext())
            {
                // var item = context.ToDos.FirstOrDefault(t => t.ToDoId == id);
                
                var item = context.ToDos.Find(id);
                if (item == null)
                    return NotFound();
                return Ok(new ToDoListVM { ToDoId = item.ToDoId, 
                    UserName = item.User.UserName, 
                    Title = item.Title, 
                    Description = item.Description,
                    LastCompleted = item.ToDoEvents.OrderByDescending(j => j.OccurredDttm).Select(k => k.OccurredDttm).FirstOrDefault()
                });

            }
        }

        public HttpResponseMessage PostTodo(ToDoListVM toDoIn)
        {
            var context = new ToDoContext();
            var newToDo = new ToDo {Title = toDoIn.Title, Description = toDoIn.Description, UserId = 1};

            context.ToDos.Add(newToDo);
            context.SaveChanges();
            // Gives the 201 created response.
            toDoIn.ToDoId = newToDo.ToDoId;
            var response = Request.CreateResponse<ToDoListVM>(HttpStatusCode.Created, toDoIn );
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newToDo.ToDoId }));
            
            return response;
        }

        // DELETE: api/Todo/5
        public IHttpActionResult DeleteToDo(int id)
        {
            var context = new ToDoContext();

            ToDo toDo = context.ToDos.Find(id);
            if (toDo == null)
            {
                return NotFound();
            }

            context.ToDos.Remove(toDo);
            context.SaveChanges();

            return Ok();
        }

    }
}
