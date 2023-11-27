using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBancoDeDados.entidades
{
    class Categorias
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categorias(int id)
        {
            Id = id;
        }
        public Categorias(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
