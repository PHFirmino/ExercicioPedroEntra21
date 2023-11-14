namespace interfaces_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gato gato = new Gato();
            gato.dormir();
            gato.comer();
            gato.beber();

            Console.ReadKey();
        }
    }
}