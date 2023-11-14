using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    class Carro
    {
        string Modelo { get; set; }
        string Marca { get; set; }
        string Placa { get; set; }
        string Cor { get; set; }

        public Carro(string modelo, string marca, string placa, string cor)
        {
            this.Modelo = modelo;
            this.Marca = marca;
            this.Placa = placa;
            this.Cor = cor;
        }
        public static void mostrarLista(List<Carro> carros)
        {
            foreach (Carro carro in carros)
            {
                Console.WriteLine($"Placa: {carro.Placa} - Marca: {carro.Marca} - Modelo: {carro.Modelo} - Cor: {carro.Cor}");
            }
        }
        public static void adicionarLista(List<Carro> carros)
        {
            Console.WriteLine("Adicionar Marca: ");
            string marca = Console.ReadLine();

            Console.WriteLine("Adicionar Modelo: ");
            string modelo = Console.ReadLine();

            Console.WriteLine("Adicionar Cor: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Adicionar Placa: ");
            string placa = Console.ReadLine();

            Carro carro = new Carro(modelo, marca, placa, cor);

            carros.Add(carro);
        }
        public static void removerLista(List<Carro> carros)
        {
            Console.WriteLine("Adicionar Placa do carro para remoção: ");
            string placa = Console.ReadLine();

            Carro variavel = null;
            bool passou = false;

            foreach (Carro carro in carros)
            {
                if (carro.Placa.Equals(placa))
                {
                    variavel = carro;
                    passou = true;

                    break;
                }
            }

            if (passou == true)
            {
                carros.Remove(variavel);
                Console.WriteLine("Carro removido com Sucesso");
            }
            else
            {
                Console.WriteLine("Não possui esse carro");
            }
        }
        public static void alterarlista(List<Carro> carros)
        {
            Console.WriteLine("Adicionar Placa do carro para alteração: ");
            string placa = Console.ReadLine();

            Carro variavel = null;
            bool passou = false;

            foreach (Carro carro in carros)
            {
                if (carro.Placa.Equals(placa))
                {
                    variavel = carro;
                    passou = true;
                    break;
                }
            }

            if (passou == true)
            {
                Console.WriteLine("Mudar Marca: ");
                variavel.Marca = Console.ReadLine();

                Console.WriteLine("Mudar Modelo: ");
                variavel.Modelo = Console.ReadLine();

                Console.WriteLine("Adicionar Cor: ");
                variavel.Cor = Console.ReadLine();

                Console.WriteLine("Adicionar Placa: ");
                variavel.Placa = Console.ReadLine();

                Console.WriteLine("Alteração feita com sucesso");
            }
            else
            {
                Console.WriteLine("Não possui esse carro");
            }
        }
    }
}

