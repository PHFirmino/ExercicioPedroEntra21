using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBancoDeDados.interfaceMostrarIndividual
{
    interface IMostrarIndividual<T>
    {
        public void mostraIndividual(T t);
    }
}
