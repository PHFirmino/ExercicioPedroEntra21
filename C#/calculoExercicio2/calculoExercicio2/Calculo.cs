using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculoExercicio2
{
    class Calculo
    {
        public int n1;
        public int n2;

        public string adicao()
        {
            return $"Adição: {n1 + n2}";
        }
        public string subtracao()
        {
            return $"Subtração: {n1 - n2}";
        }
        public string multiplicacao()
        {
            return $"Multiplicação: {n1 * n2}";
        }
        public string divisao()
        {
            return $"Divisão: {n1 / n2}";
        }
    }
}
