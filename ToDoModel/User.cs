//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToDoModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.ToDos = new HashSet<ToDo>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime JoinDate { get; set; }
    
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
