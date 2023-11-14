namespace produtosExercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Produtos produtos = new Produtos();
            produtos.codigo = "1";
            produtos.descricao = "Cadeira";
            produtos.valorUnitario = 10;

            produtos.infoProduto();

            Console.ReadKey();
        }
    }
}