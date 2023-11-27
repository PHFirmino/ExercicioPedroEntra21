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
    class CrudCategoria : ICrud<Bd>
    {
        public void addBanco(Bd t)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Digite um código para o Categoria");
                int codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite um nome para o Categoria");
                string nome = Console.ReadLine();

                Categorias categorias = new Categorias(codigo, nome);

                Console.WriteLine(t.salvarCategoria(categorias).Replace("True", ""));

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
            List<Categorias> listaCategorias = new List<Categorias>();

            while (continuar)
            {
                bool passou = false;
                Console.WriteLine("Digite o código da Categoria que deseja alterar");
                int codigoCategoria = Convert.ToInt32(Console.ReadLine());

                t.verificarCategoria(listaCategorias);

                foreach (Categorias categorias in listaCategorias)
                {
                    if (categorias.Id == codigoCategoria)
                    {
                        Console.WriteLine("Digite o novo nome da Categoria");
                        string nomeCategoria = Console.ReadLine();

                        Categorias categoria = new Categorias(codigoCategoria, nomeCategoria);

                        Console.WriteLine(t.alterarCategoriaBD(categoria).Replace("True", ""));

                        t.mostrarCategoriaBD(listaCategorias);

                        passou = true;
                        break;
                    }
                }

                if (passou == false)
                {
                    Console.WriteLine("Não possui esse ID em categorias");
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
            List<Categorias> categorias = new List<Categorias>();
            t.mostrarCategoriaBD(categorias);
        }

        public void removerBD(Bd t)
        {
            bool continuar = true;
            List<Categorias> listaCategorias = new List<Categorias>();
            List<Produtos> listaProdutos = new List<Produtos>();

            while (continuar)
            {
                bool passou = false;
                bool passouOutraVez = false;

                Console.WriteLine("Digite o código da Categoria que deseja remover");
                int codigoCategoria = Convert.ToInt32(Console.ReadLine());

                t.verificarCategoria(listaCategorias);

                foreach (Categorias categorias in listaCategorias)
                {
                    if (categorias.Id == codigoCategoria)
                    {
                        passou = true;
                        break;
                    }
                }

                if (passou == true)
                {
                    t.verificarProduto(listaProdutos);

                    foreach (Produtos produtos in listaProdutos)
                    {
                        if (produtos.Id_categorias.Id == codigoCategoria)
                        {
                            Console.WriteLine("Essa categoria não pode ser removida, produtos possuem ela");
                            passouOutraVez = true;
                            break;
                        }
                    }

                    if (passouOutraVez == false)
                    {
                        Console.WriteLine(t.removerCategoria(codigoCategoria).Replace("True", ""));
                    }
                }
                else
                {
                    Console.WriteLine("Não possui esse ID em categorias");
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
