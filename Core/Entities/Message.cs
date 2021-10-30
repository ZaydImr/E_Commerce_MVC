using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Message : EntityBase
    {
        public string Content { get; set; }
        public DateTime DateMessage { get; set; }

        public string usernameProvider { get; set; }
        public User UserProvider { get; set; }
        public string usernameReceiver { get; set; }
        public User UserReceiver { get; set; }
    }
}
