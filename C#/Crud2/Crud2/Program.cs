namespace Crud2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produtos> produtos = new List<Produtos>();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Produtos           Ver Produtos[1] Adicionar Produto[2] Remover Produto[3] Alterar Lista[4]");

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                int escolha = 0;

                while (escolha <= 0 || escolha > 4)
                {
                    Console.WriteLine("Digite o deseja fazer");
                    escolha = Convert.ToInt32(Console.ReadLine());
                }

                switch (escolha)
                {
                    case 1:
                        Produtos.mostrarLista(produtos);
                        break;
                    case 2:
                        Produtos.adicionarLista(produtos);
                        break;
                    case 3:
                        Produtos.removerLista(produtos);
                        break;
                    case 4:
                        Produtos.alterarlista(produtos);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}