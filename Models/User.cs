using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public partial class User
    {
        public User()
        {
            TaskComments = new HashSet<TaskComment>();
            TaskLists = new HashSet<TaskList>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
        public byte[] CreatedAt { get; set; } = null!;

        public virtual ICollection<TaskComment> TaskComments { get; set; }
        public virtual ICollection<TaskList> TaskLists { get; set; }
    }
}
