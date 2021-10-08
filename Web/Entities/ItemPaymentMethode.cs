using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities
{
    public class ItemPaymentMethode : EntityBase
    {
        public Item Item { get; set; }
        public PaymentMethode PaymentMethode { get; set; }
    }
}
