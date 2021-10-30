using System.Collections.Generic;

namespace Core.Entities
{
    public class PaymentMethode : EntityBase
    {
        public string NameMethode { get; set; }
        public ICollection<ItemPaymentMethode> itemPaymentMethodes { get; set; }
        public ICollection<Commande> commandes { get; set; }
    }
}
