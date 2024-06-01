using System;
using System.Xml.Serialization;

namespace TodoWPF.Model
{
    public sealed class Task
    {
        internal Guid Id { get; set; }
        internal Guid CustomerId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title, Guid customerId)
        {
            Title = title;
            Id = Guid.NewGuid();
            CustomerId = customerId;
        }
    }
}
