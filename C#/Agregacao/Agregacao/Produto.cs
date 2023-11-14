using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agregacao
{
    class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set;}

        public double Preco { get; set; }
        public Categoria Categoria { get; set;}

        public Produto(int id, string descricao, double preco, Categoria categoria)
        {
            this.Id = id;
            this.Descricao = descricao;
            this.Preco = preco;
            this.Categoria = categoria;
        }

        public string msg()
        {
            return $"{Id} {Descricao} {Preco} {Categoria.msg()}";
        }
    }
}
