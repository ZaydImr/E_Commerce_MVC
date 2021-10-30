using System.Collections.Generic;

namespace Core.Entities
{
    public class Category : EntityBase
    {
        public string NameCategory { get; set; }
        public ICollection<Item> items { get; set; }

    }
}
