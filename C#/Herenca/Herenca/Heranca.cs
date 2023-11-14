using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herenca
{
    class Veiculo
    {
        public string Marca { get; set; }
        public virtual void barulho()
        {
            Console.WriteLine("Vrummm");
        }
    }
    class Carro : Veiculo
    { 
        public string Modelo { get; set; }

        public override void barulho()
        {
            Console.WriteLine("Vrummm carro");
        }
    }

    class Pessoa
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string mostrarPessoa()
        {
            return $"{Id} {Name}";
        }
    }
    class Cliente : Pessoa 
    {
        public string Cpf { get; set; }

        public string mostrarPessoa()
        {
            string msg = base.mostrarPessoa();

            return $"{msg} {Cpf}";

        }
    }
}
