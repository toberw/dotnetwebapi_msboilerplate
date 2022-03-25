using System;
using System.Collections.Generic;

namespace ContosoPizza.Models
{
    public partial class TaskComment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ItemId { get; set; }
        public string? Value { get; set; }

        public virtual TaskItem? Item { get; set; }
        public virtual User? User { get; set; }
    }
}
