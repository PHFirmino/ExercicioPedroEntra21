using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquivoTexto
{
    class Produto
    {
        public string Descricao { get; set; }

        private double valor;
        public string Valor
        {
            get
            {
                return $"{valor}";
            }
            set
            {
                if (value.GetType() == typeof(string))
                {
                    valor = Convert.ToDouble(value); 
                }
            }
        }

        private int codigo;
        public string Codigo 
        { 
            get
            {
                return $"{codigo}";
            }
            set
            {
                if(value.GetType() == typeof(string))
                {
                    codigo = Convert.ToInt32(value);
                }
            } 
        }

        public Produto(string codigo, string descricao, string valor)
        {
            this.Descricao = descricao;
            this.Valor = valor;
            this.Codigo = codigo;
        }
    }
}
