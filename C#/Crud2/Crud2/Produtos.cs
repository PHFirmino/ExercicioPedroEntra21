using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud2
{
    class Produtos
    {
        int Codigo { get; set; }
        string Descricao { get; set; }
        int Estoque { get; set; }
        double ValorUnitario { get; set; }

        private double valorTaxa;
        private double valorDesconto;
        private double valorTotal;

        public Produtos(int codigo, string descricao, int estoque, double valorUnitario)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.Estoque = estoque;
            this.ValorUnitario = valorUnitario;
            valorDesconto = valorUnitario / 100 * 2;
            valorTaxa = valorUnitario / 100 * 10;
            valorTotal = valorUnitario - valorDesconto + valorTaxa;
        }
        public static void mostrarLista(List<Produtos> produtos)
        {
            foreach (Produtos produto in produtos)
            {
                Console.WriteLine($"Código: {produto.Codigo} - Descricao: {produto.Descricao} - Estoque: {produto.Estoque}");
                Console.WriteLine($"Valor desconto: {produto.valorDesconto} - Valor taxa: {produto.valorTaxa} - Valor total: {produto.valorTotal}");
            }
        }
        public static void adicionarLista(List<Produtos> produtos)
        {
            Console.WriteLine("Adicionar Código: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Adicionar Descrição: ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Adicionar Estoque: ");
            int estoque = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Adicionar Valor Unitário: ");
            double valorUnitário = Convert.ToDouble(Console.ReadLine());

            Produtos produto = new Produtos(codigo, descricao, estoque, valorUnitário);

            produtos.Add(produto);
        }
        public static void removerLista(List<Produtos> produtos)
        {
            Console.WriteLine("Adicionar Código do produto para remoção: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Produtos variavel = null;
            bool passou = false;

            foreach (Produtos produto in produtos)
            {
                if (codigo == produto.Codigo)
                {
                    variavel = produto;
                    passou = true;

                    break;
                }
            }

            if (passou == true)
            {
                produtos.Remove(variavel);
                Console.WriteLine("Produto removido com Sucesso");
            }
            else
            {
                Console.WriteLine("Não possui esse produto");
            }
        }
        public static void alterarlista(List<Produtos> produtos)
        {
            Console.WriteLine("Adicionar Código do produto para alteração: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Produtos variavel = null;
            bool passou = false;

            foreach (Produtos produto in produtos)
            {
                if (codigo == produto.Codigo)
                {
                    variavel = produto;
                    passou = true;
                    break;
                }
            }

            if (passou == true)
            {
                Console.WriteLine("Mudar Código: ");
                variavel.Codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Mudar Descrição: ");
                variavel.Descricao = Console.ReadLine();

                Console.WriteLine("Adicionar Estoque: ");
                variavel.Estoque = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Adicionar Valor Unitário: ");
                variavel.ValorUnitario = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Alteração feita com sucesso");
            }
            else
            {
                Console.WriteLine("Não possui esse produto");
            }
        }
    }
}
