using System.IO;

namespace arquivoTexto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "Altere o caminho do arquivo";
            bool continuar = true;

            List<Produto> produtos = new List<Produto>();

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() != -1)
                    {
                        string codigoArquivo = sr.ReadLine().Replace("Código:", "");
                        string descricaoArquivo = sr.ReadLine().Replace("Descrição:", "");
                        string valorArquivo = sr.ReadLine().Replace("Valor:", "");

                        Produto produto = new Produto(codigoArquivo, descricaoArquivo, valorArquivo);
                        produtos.Add(produto);
                    }
                }
            }

            while (continuar)
            {
                Console.WriteLine("Deseja adicionar ou remover [A/R/U/S]");
                string acao = Console.ReadLine().ToUpper();

                switch (acao)
                {
                    case "A":
                        adicionar(path, produtos);
                        break;
                    case "R":
                        remover(produtos, path);
                        break;
                    case "U":
                        att(produtos, path);
                        break;
                    case "S":
                        mostrarArquivo(path, produtos);
                        break;
                    default:
                        continuar = false;
                        break;
                }
            }
        }
        static void adicionar(string path, List<Produto> produtos)
        {
            bool continuar = true;

            while (continuar)
            {
                bool passou = false;

                Console.WriteLine("Digite o código: ");
                string codigo = Console.ReadLine();

                Console.WriteLine("Digite a descrição: ");
                string descricao = Console.ReadLine();

                Console.WriteLine("Digite o preço");
                string preco = Console.ReadLine();

                foreach (Produto produtoItem in produtos)
                {
                    if (descricao == produtoItem.Descricao)
                    {
                        passou = true;
                        Console.WriteLine("Já possui esse produto na lista");
                        break;
                    }
                }

                if (passou == false)
                {
                    Produto produto = new Produto(codigo, descricao, preco);
                    produtos.Add(produto);
                }

                Console.WriteLine("Deseja adicionar mais [S/N]");
                string msgContinuar = Console.ReadLine().ToUpper();

                if (msgContinuar == "N")
                {
                    continuar = false;
                }
            }

            mostrarArquivo(path, produtos);
        }
        static void remover(List<Produto> produtos, string path)
        {
            Produto produtoRecebido = verificar(produtos);

            if (produtoRecebido != null)
            {
                produtos.Remove(produtoRecebido);
                Console.WriteLine("Produto removido com SUCESSO!");
            }
            else
            {
                Console.WriteLine("Esse código NÃO existe");
            }

            mostrarArquivo(path, produtos);
        }
        static void att(List<Produto> produtos, string path)
        {
            Produto produtoRecebido = verificar(produtos);

            if (produtoRecebido != null)
            {
                Console.WriteLine("Digite o código: ");
                produtoRecebido.Codigo = Console.ReadLine();

                Console.WriteLine("Digite a descrição: ");
                produtoRecebido.Descricao = Console.ReadLine();

                Console.WriteLine("Digite o preço");
                produtoRecebido.Valor = Console.ReadLine();

                Console.WriteLine("Produto ALTERADO com SUCESSO");
            }
            else
            {
                Console.WriteLine("Esse código NÃO existe");
            }

            mostrarArquivo(path, produtos);
        }
        static Produto verificar(List<Produto> produtos)
        {
            Console.WriteLine("Digite o código do produto:");
            string codigo = Console.ReadLine();

            bool passou = false;
            Produto produtoEx = null;

            foreach (Produto produtoItem in produtos)
            {
                if (codigo == produtoItem.Codigo)
                {
                    produtoEx = produtoItem;
                    passou = true;
                }
            }

            if(passou == true)
            {
                return produtoEx;
            }

            return produtoEx;
        }
        static void mostrarArquivo(string path, List<Produto> produtos)
        {
            File.Delete(path);

            using (StreamWriter sw = File.AppendText(path))
            {

                foreach (Produto produtoItem in produtos)
                {
                    sw.WriteLine($"Código:{produtoItem.Codigo}");
                    sw.WriteLine($"Descrição:{produtoItem.Descricao}");
                    sw.WriteLine($"Valor:{produtoItem.Valor}");
                }
            }

            System.Diagnostics.Process.Start("notepad.exe", path);
        }
    }
}