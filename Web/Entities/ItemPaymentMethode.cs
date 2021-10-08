using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ItemPaymentMethode : EntityBase
    {
        public Item Item { get; set; }
        public PaymentMethode PaymentMethode { get; set; }
    }
}
