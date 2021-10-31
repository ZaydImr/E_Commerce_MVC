using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string phoneNumber { get; set; }
        public string fixNumber { get; set; }
        public string AdresseUser { get; set; }
        public string imgPath { get; set; }
        public string websiteUrl { get; set; }

        [ForeignKey("fk_User_TypeUser")]
        public Guid idTypeUser { get; set; }
        public TypeUser TypeUser { get; set; }

        public ICollection<Message> messagesSender { get; set; }
        public ICollection<Message> messagesReceiver { get; set; }
        public ICollection<Item> items { get; set; }
        public ICollection<Delivery> deliveries { get; set; }
        public ICollection<Commande> commandes { get; set; }
        public ICollection<Cart> carts { get; set; }
    }
}
