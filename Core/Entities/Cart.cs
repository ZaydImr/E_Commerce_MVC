using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities
{
    public class Cart : EntityBase
    {
        public int Qte { get; set; }

        [ForeignKey("fk_Cart_User")]
        public string idUser { get; set; }
        public User User { get; set; }

        [ForeignKey("fk_Cart_Item")]
        public Guid idItem { get; set; }
        public Item Item { get; set; }
    }
}
