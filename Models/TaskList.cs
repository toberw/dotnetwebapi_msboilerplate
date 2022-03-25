using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public partial class TaskList
    {
        public TaskList()
        {
            TaskItems = new HashSet<TaskItem>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public byte[] CreatedAt { get; set; } = null!;
        public string? Value { get; set; }
        public string? Description { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<TaskItem> TaskItems { get; set; }
    }
}
