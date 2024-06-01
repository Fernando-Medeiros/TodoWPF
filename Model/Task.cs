using System;

namespace TodoWPF.Model
{
    public sealed class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public Guid CustomerId { get; set; }
    }
}
