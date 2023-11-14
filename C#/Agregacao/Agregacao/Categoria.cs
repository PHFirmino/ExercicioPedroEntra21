using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agregacao
{
    class Categoria
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public Categoria(int id, string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public string msg()
        {
            return $"{Id} {Descricao}";
        }
    }
}
