namespace agendaMVC.Models
{
    public class Compromisso
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public Local Local { get; set; }
        public Contato Contato { get; set; }
        public string Status { get; set; }

        public Compromisso() { }

        public Compromisso(int id, string data, string hora, Local local, Contato contato, string status)
        {
            this.Id = id;
            this.Data = data;
            this.Hora = hora;
            this.Local = local;
            this.Contato = contato;
            this.Status = status;
        }
    }
}
