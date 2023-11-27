using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBancoDeDados.dao;
using CrudBancoDeDados.entidades;
using CrudBancoDeDados.interfaceCrud;

namespace CrudBancoDeDados.cruds
{
    class CrudProduto : ICrud<Bd>
    {
        public void addBanco(Bd t)
        {
            bool continuar = true;
            List<Categorias> listaCategorias = new List<Categorias>();

            while (continuar)
            {
                bool passou = false;
                Console.WriteLine("Digite um Código para o Produto");
                int codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite um Nome para o Produto");
                string nome = Console.ReadLine();

                Console.WriteLine("Digite o Valor do Produto");
                float valor = (float)Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Digite a Quantidade do Produto:");
                int qnt = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite o código da Categoria:");
                int codigoCategoria = Convert.ToInt32(Console.ReadLine());

                t.verificarCategoria(listaCategorias);

                foreach (Categorias categorias in listaCategorias)
                {
                    if (categorias.Id == codigoCategoria)
                    {
                        Categorias categoria = new Categorias(codigoCategoria);

                        Produtos produto = new Produtos(codigo, nome, valor, qnt, categoria);
                        Console.WriteLine(t.salvarProduto(produto).Replace("True", ""));

                        passou = true;
                        break;
                    }
                }

                if (passou == false)
                {
                    Console.WriteLine("Não possui esse ID em categorias");
                }

                Console.WriteLine("Deseja continuar adicionando [S] / [N]");
                string msgContinuar = Console.ReadLine().ToUpper();

                if (msgContinuar == "N")
                {
                    continuar = false;
                }
            }
        }

        public void alterarBD(Bd t)
        {
            bool continuar = true;
            List<Produtos> listaProdutos = new List<Produtos>();
            List<Categorias> listaCategorias = new List<Categorias>();

            while (continuar)
            {
                bool passou = false;
                bool passouOutraVez = false;
                Console.WriteLine("Digite o código do Produto que deseja alterar");
                int codigoProduto = Convert.ToInt32(Console.ReadLine());

                t.verificarProduto(listaProdutos);

                foreach (Produtos produtos in listaProdutos)
                {
                    if (produtos.Id == codigoProduto)
                    {
                        passou = true;
                        break;
                    }
                }

                if (passou == true)
                {
                    Console.WriteLine("Digite um novo Nome para o Produto");
                    string nome = Console.ReadLine();

                    Console.WriteLine("Digite o novo Valor do Produto");
                    float valor = (float)Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Digite a nova Quantidade do Produto:");
                    int qnt = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite o novo código da Categoria:");
                    int codigoCategoria = Convert.ToInt32(Console.ReadLine());

                    t.verificarCategoria(listaCategorias);

                    foreach (Categorias categorias in listaCategorias)
                    {
                        if (categorias.Id == codigoCategoria)
                        {
                            Categorias categoria = new Categorias(codigoCategoria);

                            Produtos produto = new Produtos(nome, valor, qnt, categoria);

                            Console.WriteLine(t.alterarProdutoBD(codigoProduto, produto).Replace("True", ""));

                            t.mostrarProdutoBD(listaProdutos);

                            passouOutraVez = true;

                            break;
                        }
                    }

                    if (passouOutraVez == false)
                    {
                        Console.WriteLine("NÃO possui esse ID de categoria");
                    }
                }
                else
                {
                    Console.WriteLine("Não possui esse Id de produto");
                }

                Console.WriteLine("Deseja continuar alterando [S] / [N]");
                string msgContinuar = Console.ReadLine().ToUpper();

                if (msgContinuar == "N")
                {
                    continuar = false;
                }
            }
        }


        public void mostraBD(Bd t)
        {
            List<Produtos> produtos = new List<Produtos>();
            t.mostrarProdutoBD(produtos);
        }

        public void removerBD(Bd t)
        {
            List<Produtos> listaProdutos = new List<Produtos>();
            bool continuar = true;

            while (continuar)
            {
                bool passou = false;

                Console.WriteLine("Digite o código do Produto que deseja remover");
                int codigoProduto = Convert.ToInt32(Console.ReadLine());

                t.verificarProduto(listaProdutos);

                foreach (Produtos produtos in listaProdutos)
                {
                    if (produtos.Id == codigoProduto)
                    {
                        passou = true;
                        Console.WriteLine(t.removerProdutos(codigoProduto).Replace("True", ""));
                        break;
                    }
                }

                if (passou == false)
                {
                    Console.WriteLine("Não possui esse ID de produto");
                }

                Console.WriteLine("Deseja continuar removendo [S] / [N]");
                string msgContinuar = Console.ReadLine().ToUpper();

                if (msgContinuar == "N")
                {
                    continuar = false;
                }
            }
        }
    }
}
