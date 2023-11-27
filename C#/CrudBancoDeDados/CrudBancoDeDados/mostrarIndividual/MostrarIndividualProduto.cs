using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBancoDeDados.dao;
using CrudBancoDeDados.entidades;
using CrudBancoDeDados.interfaceMostrarIndividual;

namespace CrudBancoDeDados.mostrarIndividual
{
    class MostrarIndividualProduto : IMostrarIndividual<Bd>
    {
        public void mostraIndividual(Bd b)
        {
            List<Produtos> listaProduto = new List<Produtos>();
            bool continuar = true;

            while (continuar)
            {
                bool passou = false;

                Console.WriteLine("Digite o ID de uma categoria para ver produto os relacionado a ela:");
                int id = Convert.ToInt32(Console.ReadLine());

                b.verificarProduto(listaProduto);

                foreach (Produtos produtoItem in listaProduto)
                {
                    if (produtoItem.Id_categorias.Id == id)
                    {
                        b.mostrarIndividualProduto(id, listaProduto);
                        passou = true;
                        break;
                    }
                }

                if (passou == false)
                {
                    Console.WriteLine("Não possui esse ID de categoria em produtos");
                }

                Console.WriteLine("Deseja continuar listando [S] / [N]");
                string msgContinuar = Console.ReadLine().ToUpper();

                if (msgContinuar == "N")
                {
                    continuar = false;
                }
            }
        }
    }
}
