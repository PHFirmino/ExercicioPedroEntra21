using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBancoDeDados.entidades
{
    class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float Valor { get; set; }
        public int Qnt { get; set; }
        public Categorias Id_categorias { get; set; }

        public Produtos(string nome, float valor, int qnt, Categorias categorias)
        {
            Nome = nome;
            Valor = valor;
            Qnt = qnt;
            Id_categorias = categorias;
        }
        public Produtos(int id, string nome, float valor, int qnt, Categorias categorias)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            Qnt = qnt;
            Id_categorias = categorias;
        }
    }
}
