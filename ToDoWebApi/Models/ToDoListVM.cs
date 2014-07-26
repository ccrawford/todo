using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoWebApi.Models
{
    public class ToDoListVM
    {
        public int ToDoId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime LastCompleted { get; set; }
    }
}