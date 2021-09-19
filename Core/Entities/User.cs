namespace Core.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Numero { get; set; }
        public string AdresseUser { get; set; }
        public TypeUser TypeUser { get; set; }
    }
}
