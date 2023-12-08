using System.Reflection.Metadata;

namespace agendaMVC.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }

        public Contato() { }

        public Contato(string email)
        {
            this.Email = email;
        }
        public Contato(int id, string name, string email, string fone) 
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Fone = fone;
        }
    }
}