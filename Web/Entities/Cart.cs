using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Entities
{
    public class Cart : EntityBase
    {
        public User User { get; set; }
        public int Qte { get; set; }
        public Item Item { get; set; }
    }
}
