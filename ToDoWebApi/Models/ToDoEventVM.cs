using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoWebApi.Models
{
    public class ToDoEventVM
    {
        public string UserName { get; set; }
        public int TodoId { get; set; }
        public int TodoEventId { get; set; }
        public System.DateTime  OccurredDttm { get; set; }
        public string Rating { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}
