using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class ItemPaymentMethode : EntityBase
    {
        public Item Item { get; set; }
        public int idItem { get; set; }

        [ForeignKey("fk_ItemPaymentMethode_PaymentMethode")]
        public Guid idPaymentMethode { get; set; }
        public PaymentMethode PaymentMethode { get; set; }
    }
}
