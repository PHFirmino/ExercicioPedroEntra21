using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBancoDeDados.interfaceCrud
{
    interface ICrud<T>
    {
        public void addBanco(T t);
        public void mostraBD(T t);
        public void alterarBD(T t);
        public void removerBD(T t);
    }
}
