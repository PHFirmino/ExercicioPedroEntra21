using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static interfaces_.IAnimal;

namespace interfaces_
{
    interface IAnimal
    {
        void dormir();
        void comer();
        void beber();
    }

    class Gato : IAnimal
    {
        public void beber()
        {
            Console.WriteLine("glub, glub");
        }

        public void comer()
        {
            Console.WriteLine("inhec, inhec");
        }

        public void dormir()
        {
            Console.WriteLine("ZzZzZ");
        }
    }

}
