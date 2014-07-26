using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoModel;
using System.Data.Entity;

namespace ToDoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
          //  GetToDos(1);
          //  AddUser();
          //  AddTodo();
            GetToDos("ccrawford");
          
            Console.ReadKey();
        }

        private static void AddTodo()
        {
            var user = new User { FirstName = "Will", LastName = "Crawford", JoinDate = DateTime.Now, UserName = "wcrawford" };
            user.ToDos.Add(new ToDo { Description = "Feed the dog two scoops", Title = "Feed dog" });
            
            using (var context = new ToDoContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        private static void AddUser()
        {
            var user = new User { FirstName = "Therese", LastName = "Crawford", JoinDate = DateTime.Now, UserName = "tcrawford" };
            using (var context = new ToDoContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            Console.Write(user.UserId);
        }

        private static void GetToDos(int p)
        {
            using(var context = new ToDoContext())
            {
                var todo = context.ToDos.Find(p);
                Console.Write(todo.Description);
            }
        }

        private static void GetToDos(string userName)
        {
            using (var context = new ToDoContext())
            {
                var todo = context.ToDos.Where(c => c.User.UserName == userName).FirstOrDefault();
                Console.Write(todo.Description);
            }
        }

        private static void GetToDos()
        {
            using (var context = new ToDoContext())
            {

                foreach (ToDoModel.ToDo todo in context.ToDos)
                {
                    Console.WriteLine(todo.Title);
                }

            }
        }
    }
}
