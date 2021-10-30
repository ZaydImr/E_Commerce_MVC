using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("fk_Item_User")]
        public string idUser { get; set; }
        public User User { get; set; }

        [ForeignKey("fk_Item_Category")]
        public Guid idCategory { get; set; }
        public Category Category { get; set; }

        [ForeignKey("fk_Item_Image")]
        public Guid idImage { get; set; }
        public Image Image { get; set; }
        public ICollection<Cart> carts { get; set; }
    }
}
