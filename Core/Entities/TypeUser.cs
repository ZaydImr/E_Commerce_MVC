using System.Collections.Generic;

namespace Core.Entities
{
    public class TypeUser : EntityBase
    {
        public string nameType { get; set; }
        public ICollection<User> users { get; set; }
    }
}
