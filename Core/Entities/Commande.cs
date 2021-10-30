using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Commande : EntityBase
    {
        public DateTime DateCommande { get; set; }
        public int QteCommande { get; set; }
        public double priceCommande { get; set; }
        public int idItem { get; set; }
        public Item Item { get; set; }

        [ForeignKey("fk_Commande_PaymentMethode")]
        public Guid idPaymentMethode { get; set; }
        public PaymentMethode PaymentMethode { get; set; }

        [ForeignKey("fk_Commande_User")]
        public string idUser { get; set; }
        public User User { get; set; }

        public ICollection<Delivery> deliveries { get; set; }
    }
}
