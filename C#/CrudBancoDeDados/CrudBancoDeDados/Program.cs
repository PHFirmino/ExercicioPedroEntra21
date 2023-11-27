using CrudBancoDeDados.cruds;
using CrudBancoDeDados.dao;
using CrudBancoDeDados.mostrarIndividual;

namespace CrudBancoDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;


            CrudCategoria crudCategoria = new CrudCategoria();
            CrudProduto Crudproduto = new CrudProduto();

            Bd banco = new Bd();

            MostrarIndividualProduto mip = new MostrarIndividualProduto();
            MostrarIndividualCategoria mic = new MostrarIndividualCategoria();

            while (continuar)
            {
                Console.WriteLine("Escolha o que deseja fazer [1]Adicionar Categoria - [2]Mostrar Categoria - [3]Alterar Categoria - [4]Remover Categoria - [5]Adicionar Produto - [6]Mostrar Produto - [7]Alterar Produto - [8]Remover Produto - [9]Mostrar Produto De Uma Categoria - [10]Mostrar Categoria Individual - [11]Sair");
                int escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        crudCategoria.addBanco(banco);
                        break;
                    case 2:
                        crudCategoria.mostraBD(banco);
                        break;
                    case 3:
                        crudCategoria.alterarBD(banco);
                        break;
                    case 4:
                        crudCategoria.removerBD(banco);
                        break;
                    case 5:
                        Crudproduto.addBanco(banco);
                        break;
                    case 6:
                        Crudproduto.mostraBD(banco);
                        break;
                    case 7:
                        Crudproduto.alterarBD(banco);
                        break;
                    case 8:
                        Crudproduto.removerBD(banco);
                        break;
                    case 9:
                        mip.mostraIndividual(banco);
                        break;
                    case 10:
                        mic.mostraIndividual(banco);
                        break;
                    case 11:
                        Console.WriteLine("Programa fechado");
                        continuar = false;
                        break;
                }

            }

            Console.ReadKey();
        }
    }
}