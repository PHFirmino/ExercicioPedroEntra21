namespace Produto.Entities
{
    public class Produtos
    {
        public long Id { get; set; }
        public string? Descricao { get; set;}
        public double? Preco { get; set;}
        public int? Estoque { get; set;}
        public Categoria? Categoria { get; set;}
        public long? Idcategoria { get; set;}
    }
}
