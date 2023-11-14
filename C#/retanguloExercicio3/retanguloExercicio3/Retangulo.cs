using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retanguloExercicio3
{
    class Retangulo
    {
        public double comprimento;
        public double altura;

        public string mostrarPerimetro()
        {
            return $"Perímetro: {comprimento * 2 + altura * 2}";
        }
        public string mostrarArea()
        {
            return $"Área: {comprimento * altura}";
        }
    }
}
