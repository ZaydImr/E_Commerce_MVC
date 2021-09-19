using System;

namespace Core.Entities
{
    public class Commande : EntityBase
    {
        public DateTime DateCommande { get; set; }
        public int QteCommande { get; set; }
        public double priceCommande { get; set; }
        public Item Item { get; set; }
        public PaymentMethode PaymentMethode { get; set; }
        public User User { get; set; }
    }
}
