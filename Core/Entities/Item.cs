using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Item : EntityBase
    {
        public string NameItem { get; set; }
        public string DescriptionItem { get; set; }
        public string AdresseItem { get; set; }
        public float PriceItem { get; set; }
        public DateTime DatePost { get; set; }
        public int QteItem { get; set; }
        public int Views { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public Image Image { get; set; }
    }
}
