namespace listEsortedListExercicios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            exercicio1();
            exercicio2();
            exercicio3();
        }
        static void exercicio1()
        {
            SortedList<string, Pessoa> pessoas = new SortedList<string, Pessoa>();

            Pessoa pessoa = new Pessoa("Pedro");

            pessoas.Add("1", pessoa);

            mostrarExercicio1(pessoas);
        }
        static void mostrarExercicio1(SortedList<string, Pessoa> pessoas)
        {
            foreach (KeyValuePair<string, Pessoa> kvp in pessoas)
            {
                Console.WriteLine(kvp.Key + " : " + kvp.Value.Nome);
            }
        }
        static void exercicio2()
        {
            List<string> produtos = new List<string>();
            mostrarExercicio2(produtos);
        }
        static void mostrarExercicio2(List<string> produtos)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Nome produto: ");
                string nomeProduto = Console.ReadLine();

                bool passou = false;

                foreach (string produtoItem in produtos)
                {
                    if (produtoItem == nomeProduto)
                    {
                        Console.WriteLine("Produto repitido");
                        passou = true;
                        break;
                    }
                }

                if (passou == false)
                {
                    produtos.Add(nomeProduto);
                }

                Console.WriteLine("Deseja continuar [S] / [N]:");
                string msgContinuar = Console.ReadLine().ToUpper();

                if (msgContinuar == "S")
                {
                    continuar = true;
                }
                else
                {
                    continuar = false;

                    foreach (string produtoItem in produtos)
                    {
                        Console.WriteLine(produtoItem);
                    }
                }
            }
        }
        static void exercicio3()
        {
            List<Produto> produtos = new List<Produto>();

            Produto produto1 = new Produto("Pão");
            produtos.Add(produto1);

            Produto produto2 = new Produto("Aveia");
            produtos.Add(produto2);

            SortedList<string, List<Produto>> categoriaProduto = new SortedList<string, List<Produto>>();
            categoriaProduto.Add("Cereais", produtos);

            foreach (KeyValuePair<string, List<Produto>> kvg in categoriaProduto)
            {
                foreach (Produto produto in kvg.Value)
                {
                    Console.WriteLine($"{kvg.Key} : {produto.Nome}");
                }
            }
        }
    }
}