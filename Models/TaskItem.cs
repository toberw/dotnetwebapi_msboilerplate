using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public partial class TaskItem
    {
        public TaskItem()
        {
            TaskComments = new HashSet<TaskComment>();
        }

        public int Id { get; set; }
        public int? ListId { get; set; }
        public string? Task { get; set; }

        public virtual TaskList? List { get; set; }
        public virtual ICollection<TaskComment> TaskComments { get; set; }
    }
}
