namespace Crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> carros = new List<Carro>();

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("LeanIt           Ver Carros[1] Adicionar Carro[2] Remover Carro[3] Alterar Lista[4]");

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
                        Carro.mostrarLista(carros);
                        break;
                    case 2:
                        Carro.adicionarLista(carros);
                        break;
                    case 3:
                        Carro.removerLista(carros);
                        break;
                    case 4:
                        Carro.alterarlista(carros);
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}