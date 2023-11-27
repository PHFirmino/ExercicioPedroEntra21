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
    class MostrarIndividualCategoria : IMostrarIndividual<Bd>
    {
        public void mostraIndividual(Bd b)
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            bool continuar = true;

            while (continuar)
            {
                bool passou = false;

                Console.WriteLine("Digite o ID para ver a categoria individualmente");
                int id = Convert.ToInt32(Console.ReadLine());

                b.verificarCategoria(listaCategorias);

                foreach (Categorias categoriaItem in listaCategorias)
                {
                    if (categoriaItem.Id == id)
                    {
                        b.mostrarIndividualCategoria(id, listaCategorias);
                        passou = true;
                        break;
                    }
                }

                if (passou == false)
                {
                    Console.WriteLine("Não possui esse ID em categorias");
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
