using System;

namespace Web.Entities
{
    public class Message : EntityBase
    {
        public string Content { get; set; }
        public DateTime DateMessage { get; set; }
        public User UserProvider { get; set; }
        public User UserReceiver { get; set; }
    }
}
