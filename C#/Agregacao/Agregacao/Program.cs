namespace Agregacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Categoria cereais = new Categoria(1, "Cereais");

            Produto produto = new Produto(1, "Pão", 10.0, cereais);

            Console.WriteLine(produto.msg());

            Console.ReadKey();
        }
    }
}