using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Delivery : EntityBase
    {
        public DateTime dateDelivery { get; set; }
        public User DileveryMan { get; set; }
        public Commande Commande { get; set; }
        public float PriceDelivery { get; set; }
        public string Status { get; set; }
    }
}
