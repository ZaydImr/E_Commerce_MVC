using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Delivery : EntityBase
    {
        public DateTime dateDelivery { get; set; }
        public float PriceDelivery { get; set; }
        public string Status { get; set; }

        [ForeignKey("fk_Delivery_User")]
        public string idDeliveryMan { get; set; }
        public User DeliveryMan { get; set; }

        [ForeignKey("fk_Delivery_Commande")]
        public Guid idCommande { get; set; }
        public Commande Commande { get; set; }
    }
}
