using System.Collections.Generic;

namespace Core.Entities
{
    public class Image : EntityBase
    {
        public string ImagePath { get; set; }
        public ICollection<Item> items { get; set; }
    }
}
