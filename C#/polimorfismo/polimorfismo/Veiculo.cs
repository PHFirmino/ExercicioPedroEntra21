using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polimorfismo
{
    class Veiculo
    {
        public virtual void som()
        {
            Console.WriteLine("Vrum");
        }
    }
    class Moto : Veiculo
    {
        public override void som()
        {
            Console.WriteLine("Bén");
        }
    }

}
