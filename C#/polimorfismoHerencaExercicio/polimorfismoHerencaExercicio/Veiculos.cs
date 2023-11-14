using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimorfismoHerencaExercicio
{
    abstract class Veiculos
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public virtual string som()
        {
            return "Vrumm";
        }
    }
    class Motos : Veiculos
    {
        public int Cilindradas { get; set; }
    }
    class MotoCorrida : Motos
    {
        public string Estilo { get; set; }

        public MotoCorrida(string marca, string estilo, string modelo, int cilindradas)
        {
            this.Marca = marca;
            this.Estilo = estilo;
            this.Modelo = modelo;
            this.Cilindradas = cilindradas;
        }

        public override string som()
        {
            return "Dééénn";
        }
    }
    class MotoNormal : Motos
    {
        public string Escapamento { get; set; }

        public MotoNormal(string marca, string escapamento, int cilindradas, string modelo)
        {
            this.Marca = marca;
            this.Cilindradas = cilindradas;
            this.Modelo = modelo;
            this.Escapamento = escapamento;
        }

        public override string som()
        {
            return "Bééénnn";
        }
    }
}
