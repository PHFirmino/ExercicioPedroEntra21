namespace agendaMVC.Models
{
    public class Local
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set;}
        public string Cep { get; set; }
        public string Uf { get; set; }

        public Local() { }

        public Local(string rua)
        {
            this.Rua = rua;
        }
        public Local(int id, string nome, string rua, int numero, string bairro, string cidade, string cep, string uf)
        {
            this.Id = id;
            this.Nome = nome;
            this.Rua = rua;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cidade = cidade;
            this.Cep = cep;
            this.Uf = uf;
        }
    }
}